# E-Commerce Platform

> A full-stack digital marketplace built with .NET 10 and React (coming soon)

[![.NET](https://img.shields.io/badge/.NET-10.0-512BD4)](https://dotnet.microsoft.com/)
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)
[![Issues](https://img.shields.io/github/issues/alvinanton/ecommerce-platform)](https://github.com/alvinanton/ecommerce-platform/issues)

## 📋 Overview

A production-ready e-commerce platform for selling digital products (e-books, courses, templates), built with Clean Architecture principles and modern development practices. This project demonstrates full-stack development skills, professional project management, and cloud deployment capabilities.

## ✨ Current Features (Week 1 - Foundation Complete!)

- ✅ Clean Architecture solution structure
- ✅ .NET 10 Web API backend
- ✅ Entity Framework Core for data access
- ✅ Professional project organization
- ✅ Git workflow and version control

## 🚀 Planned Features

**Phase 1: Foundation (Months 1-3)**
- [ ] Database design and entities
- [ ] Product catalog with categories
- [ ] Basic CRUD operations
- [ ] Repository pattern implementation
- [ ] React frontend setup

**Phase 2: Core E-Commerce (Months 4-6)**
- [ ] User authentication & authorization (JWT)
- [ ] Shopping cart functionality
- [ ] Checkout process
- [ ] Stripe payment integration
- [ ] Order management system

**Phase 3: Production Ready (Months 7-9)**
- [ ] Product reviews and ratings
- [ ] Admin dashboard
- [ ] Email notifications
- [ ] Docker containerization
- [ ] Azure cloud deployment
- [ ] CI/CD pipeline

## 🛠️ Tech Stack

**Backend:**
- .NET 10 (C#)
- ASP.NET Core Web API
- Entity Framework Core 10
- SQL Server
- JWT Authentication (planned)

**Frontend:** (Coming in Month 3)
- React 18
- Material-UI / Tailwind CSS
- Axios
- React Router

**Infrastructure:**
- Docker (planned)
- Azure App Service (planned)
- Azure SQL Database (planned)
- GitHub Actions for CI/CD (planned)

## 🏗️ Architecture

This project follows **Clean Architecture** principles with clear separation of concerns:
```
📁 Solution Structure
├── ECommerceApp.Domain          # Core business entities and interfaces
├── ECommerceApp.Application     # Business logic and use cases
├── ECommerceApp.Infrastructure  # Data access and external services
└── ECommerceApp.API             # Web API controllers and configuration
```

**Dependency Flow:**
```
API → Infrastructure → Application → Domain
```

Each layer depends only on inner layers, making the codebase:
- ✅ Testable
- ✅ Maintainable
- ✅ Scalable
- ✅ Easy to modify

## 🚀 Getting Started

### Prerequisites

- .NET 10 SDK or later
- SQL Server (Developer Edition or LocalDB)
- Visual Studio 2022 or VS Code
- Git

### Installation

1. Clone the repository
```bash
git clone https://github.com/alvinanton/ecommerce-platform.git
cd ecommerce-platform
```

2. Restore dependencies
```bash
dotnet restore
```

3. Build the solution
```bash
dotnet build
```

4. Run the API (coming in Week 2)
```bash
cd ECommerceApp.API
dotnet run
```

## 📚 Project Progress

**Completed:**
- ✅ Week 1: Development environment and solution structure

**In Progress:**
- 🔄 Week 2: Database entities and Entity Framework setup

**Upcoming:**
- ⏳ Week 3: Repository pattern and API endpoints
- ⏳ Week 4: Testing and validation

Track progress on the [Project Board](https://github.com/alvinanton/ecommerce-platform/projects)

## 📖 Learning Journey

This project is part of my software development learning journey. I'm documenting:
- Architecture decisions
- Challenges faced and solutions
- Best practices learned
- Code quality improvements

Check the [Issues](https://github.com/alvinanton/ecommerce-platform/issues) for detailed task breakdowns and progress updates.

## 🤝 Contributing

This is a personal learning project, but feedback and suggestions are welcome! Feel free to:
- Open an issue for bugs or suggestions
- Star the repo if you find it helpful
- Share your thoughts on the architecture

## 📝 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 👤 Author

**Alvin Anton**
- GitHub: [@alvinanton](https://github.com/alvinanton)
- Project: [E-Commerce Platform](https://github.com/alvinanton/ecommerce-platform)

## 🙏 Acknowledgments

- Built following Clean Architecture principles
- Inspired by Domain-Driven Design patterns
- Learning resources from Microsoft Docs and .NET community

---

⭐ **Star this repo if you find it helpful!**

🚀 **Status:** Active Development | Week 1 Complete
