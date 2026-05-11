CiNéma+
CiNéma+ est une application mobile multiplateforme développée avec .NET MAUI. Elle se connecte à l'API The Movie Database (TMDB) pour permettre l'exploration de films et la gestion d'une collection personnelle de favoris.

🚀 Fonctionnalités Actuelles
🎬 Navigation et Recherche
Films Populaires : Affichage des titres tendances récupérés directement via l'API.

Recherche en Temps Réel : La page "Recommandations" affiche une file d'attente par défaut qui bascule automatiquement vers une recherche en direct dès qu'une saisie est détectée dans la barre de recherche.

📖 Détails des Films
Fiche Complète : Affichage de l'affiche (poster), de la date de sortie, du titre et du résumé (overview).

Distribution : Section dédiée pour consulter les membres du casting.

Multimédia : Boutons intégrés pour visionner la bande-annonce et partager le lien du trailer.

📁 Gestion des Favoris
Persistance Locale : Utilisation de SQLite pour sauvegarder les films marqués d'un "cœur" sur la page de détails.

⚠️ Limites Actuelles (En cours de développement)
Bien que l'interface soit en place, les fonctionnalités suivantes ne sont pas encore opérationnelles dans cette version :

Filtrage : Les filtres par popularité et par note moyenne (vote_average) sur la page principale ne sont pas encore fonctionnels.

Pagination : Le changement de page via l'API n'est pas implémenté ; l'application affiche actuellement la première page de résultats.

Statuts de visionnement : Le système permettant de marquer un film comme "À voir", "Vu" ou "Abandonné" dans la collection n'est pas encore actif.

🛠 Technologies Utilisées
Framework : .NET MAUI (C# / XAML)

Architecture : MVVM (Model-View-ViewModel)

Base de données : SQLite

API : The Movie Database (TMDB)

⚙️ Configuration
Ouvrez CiNemaPlus.sln dans Visual Studio 2022.

Le projet est déjà configuré avec une clé API valide.

Sélectionnez votre plateforme (Android ou Windows) et lancez le débogage (F5).

👥 Contributeurs
Michaël LeBlanc
Samuel Chiasson

Projet réalisé dans le cadre du cours PROG1342.
