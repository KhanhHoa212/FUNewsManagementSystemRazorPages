using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DuongKhanhHoaRazorPages.Pages
{
    public class NewsModel : PageModel
    {
        public List<NewsArticle> Articles { get; set; } = new List<NewsArticle>();
        public List<string> Categories { get; set; } = new List<string>();

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; } = string.Empty;

        [BindProperty(SupportsGet = true)]
        public string SelectedCategory { get; set; } = string.Empty;

        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; } = 1;

        public int TotalPages { get; set; } = 1;
        public int PageSize { get; set; } = 9;

        public void OnGet()
        {
            // Initialize categories
            Categories = new List<string>
            {
                "Technology",
                "Business",
                "Education",
                "Event",
                "Announcement"
            };

            // Mock data - Replace with database calls later
            Articles = GetMockArticles();

            // Filter by search term
            if (!string.IsNullOrEmpty(SearchTerm))
            {
                Articles = Articles
                    .Where(a => a.Title.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase) ||
                               a.Excerpt.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            // Filter by category
            if (!string.IsNullOrEmpty(SelectedCategory))
            {
                Articles = Articles
                    .Where(a => a.Category == SelectedCategory)
                    .ToList();
            }

            // Calculate pagination
            TotalPages = (Articles.Count + PageSize - 1) / PageSize;
            if (PageNumber < 1) PageNumber = 1;
            if (PageNumber > TotalPages) PageNumber = TotalPages;

            // Apply pagination
            Articles = Articles
                .Skip((PageNumber - 1) * PageSize)
                .Take(PageSize)
                .ToList();
        }

        private List<NewsArticle> GetMockArticles()
        {
            return new List<NewsArticle>
            {
                new NewsArticle
                {
                    Id = 1,
                    Title = "FPT University Launches New Digital Innovation Center",
                    Excerpt = "Discover how FPT University is advancing education through cutting-edge technology and innovative learning methodologies.",
                    Category = "Education",
                    PublishDate = DateTime.Now.AddDays(-1),
                    Author = "Admin",
                    Content = "Full article content here..."
                },
                new NewsArticle
                {
                    Id = 2,
                    Title = "Artificial Intelligence Advancement in Education",
                    Excerpt = "Explore the latest developments in AI technology and how it's transforming educational experiences for students worldwide.",
                    Category = "Technology",
                    PublishDate = DateTime.Now.AddDays(-2),
                    Author = "Tech Team",
                    Content = "Full article content here..."
                },
                new NewsArticle
                {
                    Id = 3,
                    Title = "New Strategic Partnerships Announced",
                    Excerpt = "FPT University announces exciting new partnerships with leading technology companies to enhance student opportunities.",
                    Category = "Business",
                    PublishDate = DateTime.Now.AddDays(-3),
                    Author = "Business Office",
                    Content = "Full article content here..."
                },
                new NewsArticle
                {
                    Id = 4,
                    Title = "Tech Summit 2026 - Save the Date",
                    Excerpt = "Join us for the largest tech summit of the year featuring industry leaders, workshops, and networking opportunities.",
                    Category = "Event",
                    PublishDate = DateTime.Now.AddDays(-4),
                    Author = "Events Team",
                    Content = "Full article content here..."
                },
                new NewsArticle
                {
                    Id = 5,
                    Title = "Scholarship Program Expansion",
                    Excerpt = "Increased scholarship opportunities for deserving students pursuing technology and business programs at FPT University.",
                    Category = "Education",
                    PublishDate = DateTime.Now.AddDays(-5),
                    Author = "Admissions",
                    Content = "Full article content here..."
                },
                new NewsArticle
                {
                    Id = 6,
                    Title = "Major Campus Infrastructure Improvements",
                    Excerpt = "FPT University invests in state-of-the-art facilities including new labs, learning spaces, and recreational areas for students.",
                    Category = "Announcement",
                    PublishDate = DateTime.Now.AddDays(-6),
                    Author = "Facilities Team",
                    Content = "Full article content here..."
                },
                new NewsArticle
                {
                    Id = 7,
                    Title = "Cybersecurity Workshop Series Launches",
                    Excerpt = "Learn essential cybersecurity skills from industry experts in this comprehensive workshop series designed for students.",
                    Category = "Technology",
                    PublishDate = DateTime.Now.AddDays(-7),
                    Author = "IT Department",
                    Content = "Full article content here..."
                },
                new NewsArticle
                {
                    Id = 8,
                    Title = "Startup Incubator Program Opens",
                    Excerpt = "FPT University launches an innovative startup incubator program to support entrepreneurial ventures by students.",
                    Category = "Business",
                    PublishDate = DateTime.Now.AddDays(-8),
                    Author = "Entrepreneurship Center",
                    Content = "Full article content here..."
                },
                new NewsArticle
                {
                    Id = 9,
                    Title = "Alumni Networking Evening - Spring Edition",
                    Excerpt = "Connect with FPT University alumni working at top tech companies and explore career opportunities.",
                    Category = "Event",
                    PublishDate = DateTime.Now.AddDays(-9),
                    Author = "Alumni Relations",
                    Content = "Full article content here..."
                },
                new NewsArticle
                {
                    Id = 10,
                    Title = "International Exchange Program Expansion",
                    Excerpt = "New partnerships with universities worldwide enable FPT students to study and gain experience globally.",
                    Category = "Education",
                    PublishDate = DateTime.Now.AddDays(-10),
                    Author = "International Affairs",
                    Content = "Full article content here..."
                }
            };
        }
    }

    public class NewsArticle
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Excerpt { get; set; }
        public string Content { get; set; }
        public string Category { get; set; }
        public string Author { get; set; }
        public DateTime PublishDate { get; set; }
        public string ImageUrl { get; set; }
    }
}
