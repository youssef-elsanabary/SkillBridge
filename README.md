# SkillBridge
This project will serve as a freelancing platform that connects both clients that need services and freelancers that provide services. 


# Freelancing Platform

A full-stack freelancing platform built with ASP.NET Core and Angular, featuring real-time messaging using SignalR, role-based authentication, and payment processing via Stripe. This project allows users to sign up as either freelancers or clients, create services, send proposals, and manage contracts and payments.

## Table of Contents

- [Features](#features)
- [Technology Stack](#technology-stack)
- [Setup Instructions](#setup-instructions)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
  - [Database Setup](#database-setup)
  - [Running the Application](#running-the-application)
- [SignalR Integration](#signalr-integration)
  - [Real-Time Messaging](#real-time-messaging)
  - [Enabling SSL/TLS](#enabling-ssltls)
- [Database Structure](#database-structure)
- [Contributing](#contributing)
- [License](#license)

---

## Features

- User authentication (client and freelancer roles)
- Real-time messaging using SignalR
- Service creation, proposal submission, and contract management
- Payment processing with Stripe
- Role-based access control
- Email confirmation, password reset, and user profile management

## Technology Stack

- **Backend**: ASP.NET Core 8
- **Frontend**: Angular (latest version)
- **Database**: PostgreSQL (Entity Framework Core)
- **Real-Time Communication**: SignalR
- **Payment Gateway**: Stripe
- **Authentication**: JWT with role-based access control
- **Deployment**: Docker, Kubernetes

## Setup Instructions

### Prerequisites

- .NET SDK (latest version)
- Node.js and npm
- PostgreSQL
- Docker (optional for containerized development)
- Stripe account for payment integration

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/freelancing-platform.git
   cd freelancing-platform
