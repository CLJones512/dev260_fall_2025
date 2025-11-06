namespace Assignment6
{
    /// <summary>
    /// Main matchmaking system managing queues and matches
    /// Students implement the core methods in this class
    /// </summary>
    public class MatchmakingSystem
    {
        // Data structures for managing the matchmaking system
        private Queue<Player> casualQueue = new Queue<Player>();
        private Queue<Player> rankedQueue = new Queue<Player>();
        private Queue<Player> quickPlayQueue = new Queue<Player>();
        private List<Player> allPlayers = new List<Player>();
        private List<Match> matchHistory = new List<Match>();

        // Statistics tracking
        private int totalMatches = 0;
        private DateTime systemStartTime = DateTime.Now;

        /// <summary>
        /// Create a new player and add to the system
        /// </summary>
        public Player CreatePlayer(string username, int skillRating, GameMode preferredMode = GameMode.Casual)
        {
            // Check for duplicate usernames
            if (allPlayers.Any(p => p.Username.Equals(username, StringComparison.OrdinalIgnoreCase)))
            {
                throw new ArgumentException($"Player with username '{username}' already exists");
            }

            var player = new Player(username, skillRating, preferredMode);
            allPlayers.Add(player);
            return player;
        }

        /// <summary>
        /// Get all players in the system
        /// </summary>
        public List<Player> GetAllPlayers() => allPlayers.ToList();

        /// <summary>
        /// Get match history
        /// </summary>
        public List<Match> GetMatchHistory() => matchHistory.ToList();

        /// <summary>
        /// Get system statistics
        /// </summary>
        public string GetSystemStats()
        {
            var uptime = DateTime.Now - systemStartTime;
            var avgMatchQuality = matchHistory.Count > 0 
                ? matchHistory.Average(m => m.SkillDifference) 
                : 0;

            return $"""
                🎮 Matchmaking System Statistics
                ================================
                Total Players: {allPlayers.Count}
                Total Matches: {totalMatches}
                System Uptime: {uptime.ToString("hh\\:mm\\:ss")}
                
                Queue Status:
                - Casual: {casualQueue.Count} players
                - Ranked: {rankedQueue.Count} players  
                - QuickPlay: {quickPlayQueue.Count} players
                
                Match Quality:
                - Average Skill Difference: {avgMatchQuality:F1}
                - Recent Matches: {Math.Min(5, matchHistory.Count)}
                """;
        }

        // ============================================
        // STUDENT IMPLEMENTATION METHODS (TO DO)
        // ============================================

        /// <summary>
        /// 
        /// Requirements:
        /// - Add player to correct queue (casualQueue, rankedQueue, or quickPlayQueue)
        /// - Call player.JoinQueue() to track queue time
        /// - Handle any validation needed
        /// </summary>
        public void AddToQueue(Player player, GameMode mode)
        {
            // Hint: Use switch statement on mode to select correct queue
            // Don't forget to call player.JoinQueue()!
            switch (mode)
            {
                case GameMode.Casual:
                    casualQueue.Enqueue(player);
                    player.JoinQueue();
                    break;
                case GameMode.Ranked:
                    rankedQueue.Enqueue(player);
                    player.JoinQueue();
                    break;
                case GameMode.QuickPlay:
                    quickPlayQueue.Enqueue(player);
                    player.JoinQueue();
                    break;
                default:
                    Console.WriteLine("Invalid game mode");
                    break;
            }
        }

        /// <summary> 
        /// Requirements:
        /// - Return null if not enough players (need at least 2)
        /// - For Casual: Any two players can match (simple FIFO)
        /// - For Ranked: Only players within ±2 skill levels can match
        /// - For QuickPlay: Prefer skill matching, but allow any match if queue > 4 players
        /// - Remove matched players from queue and call LeaveQueue() on them
        /// - Return new Match object if successful
        /// </summary>
        public Match? TryCreateMatch(GameMode mode)
        {
            // TODO: Implement this method
            // Hint: Different logic needed for each mode
            // Remember to check queue count first!
            if (mode == GameMode.Casual)
            {
                if (casualQueue.Count >= 2)
                {
                    Player player1 = casualQueue.Dequeue();
                    player1.LeaveQueue();
                    Player player2 = casualQueue.Dequeue();
                    player2.LeaveQueue();
                    Match casualMatch = new Match(player1, player2, GameMode.Casual);
                    return casualMatch;
                }
                else
                {
                    Console.WriteLine("Not enough players in queue");
                    return null;
                }
            }
            else if (mode == GameMode.Ranked)
            {
                if (rankedQueue.Count >= 2)
                {
                    Player player1 = rankedQueue.Dequeue();
                    foreach (Player player in rankedQueue)
                    {
                        if (CanMatchInRanked(player, player1))
                        {
                            Player player2 = rankedQueue.Dequeue();
                            player2.LeaveQueue();
                            Match rankedMatch = new Match(player1, player2, GameMode.Ranked);
                            return rankedMatch;
                        }
                    }
                    rankedQueue.Enqueue(player1);
                    player1.JoinQueue();
                    Console.WriteLine("No suitable match found. Returning to queue");
                    return null;
                }
                else
                {
                    Console.WriteLine("Not enough players in queue");
                    return null;
                }
            }
            else if (mode == GameMode.QuickPlay)
            {
                if (quickPlayQueue.Count > 4)
                {
                    Player player1 = quickPlayQueue.Dequeue();
                    foreach (Player player in quickPlayQueue)
                    {
                        if (CanMatchInRanked(player, player1))
                        {
                            Player quickPlayer2 = quickPlayQueue.Dequeue();
                            quickPlayer2.LeaveQueue();
                            Match quickMatch = new Match(player1, quickPlayer2, GameMode.QuickPlay);
                            return quickMatch;
                        }
                    }
                    Player player2 = quickPlayQueue.Dequeue();
                    player2.LeaveQueue();
                    Match quickPlayMatch = new Match(player1, player2, GameMode.QuickPlay);
                    return quickPlayMatch;
                }
                else if (quickPlayQueue.Count >= 2)
                {
                    Player player1 = quickPlayQueue.Dequeue();
                    Player player2 = quickPlayQueue.Dequeue();
                    Match quickMatch = new Match(player1, player2, GameMode.QuickPlay);
                    return quickMatch;
                }
                else
                {
                    Console.WriteLine("Not enough players in queue");
                    return null;
                }

            }
            else
            {
                Console.WriteLine("Invalid Game Mode");
                return null;
            }
        }

        /// <summary>
        /// 
        /// Requirements:
        /// - Call match.SimulateOutcome() to determine winner
        /// - Add match to matchHistory
        /// - Increment totalMatches counter
        /// - Display match results to console
        /// </summary>
        public void ProcessMatch(Match match)
        {
            // TODO: Implement this method
            // Hint: Very straightforward - simulate, record, display
            match.SimulateOutcome();
            string gameSummary = match.GetSummary();
            Console.WriteLine(gameSummary);
        }

        /// <summary>
        /// 
        /// Requirements:
        /// - Show header "Current Queue Status"
        /// - For each queue (Casual, Ranked, QuickPlay):
        ///   - Show queue name and player count
        ///   - List players with position numbers and queue times
        ///   - Handle empty queues gracefully
        /// - Use proper formatting and emojis for readability
        /// </summary>
        public void DisplayQueueStatus()
        {
            // TODO: Implement this method
            // Hint: Loop through each queue and display formatted information
            Console.WriteLine("——————Casual Queue——————");
            if (casualQueue.Count >= 1)
            {
                int casualCount = 1;
                foreach (Player player in casualQueue)
                {
                    Console.WriteLine($"{casualCount}. Joined: {player.JoinedQueue}");
                    casualCount++;
                }
            }
            else
            {
                Console.WriteLine("No players in queue.");
            }

            Console.WriteLine("——————Ranked Queue——————");
            if (rankedQueue.Count >= 1)
            {
                int rankedCount = 1;
                foreach (Player player in rankedQueue)
                {
                    Console.WriteLine($"{rankedCount}. Joined: {player.JoinedQueue}, Skill Level: {player.SkillRating}");
                    rankedCount++;
                }
            }
            else
            {
                Console.WriteLine("No players in queue.");
            }

            Console.WriteLine("————Quick Play Queue————");
            if (quickPlayQueue.Count >= 1)
            {
                int quickCount = 1;
                foreach (Player player in quickPlayQueue)
                {
                    Console.WriteLine($"{quickCount}. Joined: {player.JoinedQueue}");
                    quickCount++;
                }
            }
            else
            {
                Console.WriteLine("No players in queue.");
            }
        }

        /// <summary>
        /// TODO: Display detailed statistics for a specific player
        /// 
        /// Requirements:
        /// - Use player.ToDetailedString() for basic info
        /// - Add queue status (in queue, estimated wait time)
        /// - Show recent match history for this player (last 3 matches)
        /// - Handle case where player has no matches
        /// </summary>
        public void DisplayPlayerStats(Player player)
        {
            // TODO: Implement this method
            // Hint: Combine player info with match history filtering
            Console.WriteLine(player.ToDetailedString());
            Console.WriteLine($"In queue for {player.GetQueueTime()}");
        }

        /// <summary>
        /// TODO: Calculate estimated wait time for a queue
        /// 
        /// Requirements:
        /// - Return "No wait" if queue has 2+ players
        /// - Return "Short wait" if queue has 1 player
        /// - Return "Long wait" if queue is empty
        /// - For Ranked: Consider skill distribution (harder to match = longer wait)
        /// </summary>
        public string GetQueueEstimate(GameMode mode)
        {
            // TODO: Implement this method
            // Hint: Check queue counts and apply mode-specific logic
            if (mode == GameMode.Ranked)
            {
                if (rankedQueue.Count >= 2)
                {
                    return "No wait. Wait times may be longer in this mode due to skill balancing";
                }
                else if (rankedQueue.Count == 1)
                {
                    return "Short wait. Wait times may be longer in this mode due to skill balancing";
                }
                else
                {
                    return "Long wait. Wait times may be longer in this mode due to skill balancing";
                }
            }
            else if (mode == GameMode.Casual)
            {
                if (casualQueue.Count >= 2)
                {
                    return "No wait.";
                }
                else if (casualQueue.Count == 1)
                {
                    return "Short wait.";
                }
                else
                {
                    return "No wait.";
                }
            }
            else if (mode == GameMode.QuickPlay)
            {
                if (quickPlayQueue.Count >= 2)
                {
                    return "No wait.";
                }
                else if (quickPlayQueue.Count == 1)
                {
                    return "Short wait.";
                }
                else
                {
                    return "Long wait.";
                }
            }
            else
            {
                return "Invalid game mode";
            }
        }

        // ============================================
        // HELPER METHODS (PROVIDED)
        // ============================================

        /// <summary>
        /// Helper: Check if two players can match in Ranked mode (±2 skill levels)
        /// </summary>
        private bool CanMatchInRanked(Player player1, Player player2)
        {
            return Math.Abs(player1.SkillRating - player2.SkillRating) <= 2;
        }

        /// <summary>
        /// Helper: Remove player from all queues (useful for cleanup)
        /// </summary>
        private void RemoveFromAllQueues(Player player)
        {
            // Create temporary lists to avoid modifying collections during iteration
            var casualPlayers = casualQueue.ToList();
            var rankedPlayers = rankedQueue.ToList();
            var quickPlayPlayers = quickPlayQueue.ToList();

            // Clear and rebuild queues without the specified player
            casualQueue.Clear();
            foreach (var p in casualPlayers.Where(p => p != player))
                casualQueue.Enqueue(p);

            rankedQueue.Clear();
            foreach (var p in rankedPlayers.Where(p => p != player))
                rankedQueue.Enqueue(p);

            quickPlayQueue.Clear();
            foreach (var p in quickPlayPlayers.Where(p => p != player))
                quickPlayQueue.Enqueue(p);

            player.LeaveQueue();
        }

        /// <summary>
        /// Helper: Get queue by mode (useful for generic operations)
        /// </summary>
        private Queue<Player> GetQueueByMode(GameMode mode)
        {
            return mode switch
            {
                GameMode.Casual => casualQueue,
                GameMode.Ranked => rankedQueue,
                GameMode.QuickPlay => quickPlayQueue,
                _ => throw new ArgumentException($"Unknown game mode: {mode}")
            };
        }
    }
}