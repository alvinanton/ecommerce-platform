using ECommerceApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceApp.Infrastructure.Data
{
    public static class SeedData
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            if (await context.Products.AnyAsync())
                return; // Data already seeded

            var software = new Category
            {
                Name = "Software",
                Description = "Digital software products",
                IsActive = true
            };
            var ebooks = new Category
            {
                Name = "E-books",
                Description = "Digital books",
                IsActive = true
            };
            var courses = new Category
            {
                Name = "Online Courses",
                Description = "Video courses and tutorials",
                IsActive = true
            };

            context.Categories.AddRange(software, ebooks);
            await context.SaveChangesAsync();

            // Add Products
            var products = new[]
            {
                new Product
                {
                    Name = "Adobe Photoshop 2024",
                    Description = "Professional photo editing and graphic design software with advanced tools for photographers and designers.",
                    ShortDescription = "Professional photo editing software",
                    Price = 299.99m,
                    CategoryId = software.Id,
                    IsDigital = true,
                    FileUrl = "/downloads/photoshop-2024.zip",
                    FileSize = 2147483648, // 2GB in bytes
                    ThumbnailUrl = "/images/photoshop-thumb.jpg",
                    IsActive = true
                },
                new Product
                {
                    Name = "Complete C# Programming Guide",
                    Description = "Comprehensive guide to C# programming from basics to advanced topics. Includes hundreds of code examples and exercises.",
                    ShortDescription = "Learn C# programming from scratch",
                    Price = 29.99m,
                    CategoryId = ebooks.Id,
                    IsDigital = true,
                    FileUrl = "/downloads/csharp-guide.pdf",
                    FileSize = 52428800, // 50MB
                    ThumbnailUrl = "/images/csharp-book-thumb.jpg",
                    IsActive = true
                },
                new Product
                {
                    Name = "AutoCAD 2024 Professional",
                    Description = "Industry-standard CAD software for architects, engineers, and construction professionals. Create precise 2D and 3D designs.",
                    ShortDescription = "Professional CAD software",
                    Price = 499.99m,
                    CategoryId = software.Id,
                    IsDigital = true,
                    FileUrl = "/downloads/autocad-2024.zip",
                    FileSize = 3221225472, // 3GB
                    ThumbnailUrl = "/images/autocad-thumb.jpg",
                    IsActive = true
                },
                new Product
                {
                    Name = "Web Development Masterclass",
                    Description = "Complete web development course covering HTML, CSS, JavaScript, React, Node.js, and databases. Over 40 hours of content.",
                    ShortDescription = "Complete web development course",
                    Price = 89.99m,
                    CategoryId = courses.Id,
                    IsDigital = true,
                    FileUrl = "/courses/web-dev-masterclass",
                    FileSize = 10737418240, // 10GB
                    ThumbnailUrl = "/images/webdev-course-thumb.jpg",
                    IsActive = true
                },
                new Product
                {
                    Name = "Microsoft Office 365",
                    Description = "Complete office productivity suite including Word, Excel, PowerPoint, Outlook, and more. Annual subscription.",
                    ShortDescription = "Office productivity suite",
                    Price = 149.99m,
                    CategoryId = software.Id,
                    IsDigital = true,
                    FileUrl = "/downloads/office365.exe",
                    FileSize = 4294967296, // 4GB
                    ThumbnailUrl = "/images/office365-thumb.jpg",
                    IsActive = true
                },
                new Product
                {
                    Name = "Python for Data Science",
                    Description = "Learn Python programming specifically for data science and machine learning. Includes NumPy, Pandas, and Scikit-learn.",
                    ShortDescription = "Python data science guide",
                    Price = 39.99m,
                    CategoryId = ebooks.Id,
                    IsDigital = true,
                    FileUrl = "/downloads/python-data-science.pdf",
                    FileSize = 73400320, // 70MB
                    ThumbnailUrl = "/images/python-ds-thumb.jpg",
                    IsActive = true
                },
                new Product
                {
                    Name = "Video Editing with Premiere Pro",
                    Description = "Professional video editing course teaching Adobe Premiere Pro from beginner to advanced level. 30+ hours of tutorials.",
                    ShortDescription = "Premiere Pro video editing course",
                    Price = 79.99m,
                    CategoryId = courses.Id,
                    IsDigital = true,
                    FileUrl = "/courses/premiere-pro-complete",
                    FileSize = 8589934592, // 8GB
                    ThumbnailUrl = "/images/premiere-course-thumb.jpg",
                    IsActive = true
                }
            };

            context.Products.AddRange(products);
            await context.SaveChangesAsync();

            Console.WriteLine("✅ Database seeded successfully!");
            Console.WriteLine($"   - {context.Categories.Count()} categories added");
            Console.WriteLine($"   - {context.Products.Count()} products added");
        }

    }
}
