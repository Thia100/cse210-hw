using System;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("Learn C# Basics", "Faith G.", 420);
        video1.AddComment(new Comment("Alice", "This really helped me, thank you!"));
        video1.AddComment(new Comment("Bob", "Clear and concise explanation."));
        video1.AddComment(new Comment("Charlie", "Great intro to C#!"));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video("Understanding OOP", "James M.", 530);
        video2.AddComment(new Comment("Diana", "OOP is finally making sense."));
        video2.AddComment(new Comment("Ethan", "Loved the real-world examples."));
        video2.AddComment(new Comment("Fatima", "Very informative."));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video("Working with Lists in C#", "Angela P.", 390);
        video3.AddComment(new Comment("George", "Exactly what I needed."));
        video3.AddComment(new Comment("Helen", "Easy to follow along."));
        video3.AddComment(new Comment("Isaac", "Thank you for this!"));
        videos.Add(video3);

        // Display all videos and their comments
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.Name}: {comment.Text}");
            }

            Console.WriteLine(); // Blank line between videos
        }
    }
}