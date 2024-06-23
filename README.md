# Coffee Dispenser API

A web API for managing a coffee dispenser.

## Description

Ce projet est réalisé par Mzoughi Moez.

Pour installer .NET Core 8, veuillez suivre les instructions sur le site officiel de .NET : [Installer .NET Core](https://dotnet.microsoft.com/download/dotnet-core)

### Bibliothèques Utilisées et Installation

Pour installer les bibliothèques nécessaires, utilisez les commandes suivantes :

- Entity Framework Core
```bash
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.InMemory
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```
### Serilog

dotnet add package Serilog.AspNetCore

### xUnit
```bash
dotnet add package xunit
dotnet add package xunit.runner.visualstudio
dotnet add package xunit.runner.console
```
### NSubstitute
```bash
dotnet add package NSubstitute
```
## Projects

- CoffeeDispenserAPI: MContient l'implémentation principale de l'API.
- CoffeeDispenserAPI.Tests: Contient les tests unitaires pour l'API en utilisant xUnit et NSubstitute.

## Énoncé

Développer une Web API "Distributeur à café" en .net core C# avec les fonctionnalités suivantes :

Le distributeur propose les boissons suivantes : espresso, lait, Cappuccino, chocolat chaud, café au lait, mokaccino, thé.

### Les ingrédients de base et leurs prix sont :

| Ingrédient       | Prix par dose |
|------------------|---------------|
| Lait en poudre   | 10 cents      |
| Café             | 30 cents      |
| Chocolat         | 40 cents      |
| Thé              | 30 cents      |
| Eau              | 5 cents       |

### Recettes des boissons

| Boisson          | Lait en poudre | Eau | Café | Chocolat en poudre | Thé |
|------------------|----------------|-----|------|---------------------|-----|
| Espresso         |                | 2   | 1    |                     |     |
| Lait             | 2              | 1   |      |                     |     |
| Cappuccino       | 2              | 1   | 1    | 1                   |     |
| Chocolat chaud   |                | 3   |      | 2                   |     |
| Café au lait     | 1              | 2   | 1    |                     |     |
| Mokaccino        | 1              | 2   | 1    | 2                   |     |
| Thé              | 2              |     |      |                     | 1   |

Nous appliquons une marge de 30% sur les prix des matières premières avant de définir le prix de chaque boisson.


## Refactorisation vers une architecture microservices

Pour adopter une architecture microservices, nous allons refactoriser le projet en séparant les responsabilités et en utilisant une approche basée sur les microservices. Voici comment nous allons organiser les projets :

### Projet API

- **CoffeeDispenserAPI**: Expose une API REST pour gérer les boissons et leurs prix.

### Projet Data

- **CoffeeDispenser.Data**: Contient les entités et le contexte de base de données pour gérer les données.

### Projet Infrastructure

- **CoffeeDispenser.Infrastructure**: Gère les dépendances externes, la configuration, le logging, etc.

Chaque microservice sera responsable d'une partie spécifique de l'application, favorisant ainsi la scalabilité, la résilience et le déploiement indépendant des services.