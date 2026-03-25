# 🧩 Sudoku - Visual Basic.NET Edition

Ce projet consiste en le développement d'une application de **Sudoku** complète et fonctionnelle, réalisée dans le cadre de la SAE 2.01 à l'IUT de Paris - Rives de Seine. Développé en équipe de deux étudiants, ce logiciel met l'accent sur une interface utilisateur intuitive et une logique de jeu robuste.

## 🎮 Fonctionnalités du Jeu
* **Grille Classique** : Une grille de 9x9 cases générée aléatoirement, divisée en sous-régions de 3x3.
* **Système de Niveaux** : Trois modes de difficulté sont disponibles (Facile, Moyen, Difficile) pour s'adapter à tous les profils de joueurs.
* **Challenge Contre-la-montre** : Le joueur dispose d'une limite de **7 minutes** pour résoudre le puzzle.
* **Gestion de la "Vie"** : Un système de 3 tentatives maximum par partie est implémenté pour augmenter le défi.
* **Persistance des Données** : Enregistrement des noms des joueurs et de leurs statistiques (meilleur temps, score, nombre de parties) dans un fichier `User.txt`.
* **Leaderboard** : Interface dédiée pour consulter et trier les statistiques de l'ensemble des joueurs sauvegardés.

## 🛠 Détails Techniques
* **Environnement** : Développé sous **Visual Studio** en utilisant le langage **Visual Basic.NET**.
* **Logique de Validation** : Implémentation d'un algorithme de vérification en temps réel comparant la saisie du joueur à une **DeepCopy** de la solution originale.
* **Multimédia** : Intégration de vidéos de victoire (GG) et de défaite (Lose) pour enrichir l'expérience utilisateur.
* **Easter Egg** : Une séquence de touches spécifique ("BUT01") permet d'accéder à une page de crédits interactive.

## 🚀 Installation et Lancement
1.  Cloner le dépôt GitHub : `https://github.com/Pazko77/SudokuGames`.
2.  Ouvrir le projet dans **Visual Studio**.
3.  Compiler et lancer l'application via le point d'entrée principal (`Module1.vb`).
4.  Saisir un nom de joueur dans le menu d'accueil pour commencer la partie.
