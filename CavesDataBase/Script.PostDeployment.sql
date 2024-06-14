/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
--Set Identity_insert Site on;
--INSERT INTO site (Site_Id, Site_Name, Site_Description, Latitude, Longitude, Length, Depth, AccessRequirement, PracticalInformation)VALUES
--(1, 'Trou d''Aquin', 'Trou près de Lustin', 00.00000, 00.00000, 4500.00, 56.00, 'Pas d''information pour le moment', 'Pas d''information pour le moment'),
--(2, 'Grotte Ste Anne', 'Grotte Ste Anne', 00.00001, 00.00001, 4500.00, 45.00, 'Pas d''information pour le moment', 'Pas d''information pour le moment'),
--(3, 'Reseau Chawresse-Veronika', 'Trou au dessus de Tilf', 00.00002, 00.00002, 4000.00, 96.00, 'Pas d''information pour le moment', 'Pas d''information pour le moment'),
--(4, 'Abîme de Beaumont', 'Trou sur les hauteurs d''Esneux', 00.00003, 00.00003, 516.00, 96.00, 'Pas d''information pour le moment', 'Pas d''information pour le moment'),
--(5, 'Laide Fosse', 'Trou sur les hauteurs de Han-Sur-Lesse', 00.00004, 00.00004, 2500.00, 46.00, 'Pas d''information pour le moment', 'Pas d''information pour le moment'),
--(6, 'Abîme de Lesves', 'Trou majeur du valon sec de Lesves', 00.00005, 00.00005, 1400.00, 46.00, 'Pas d''information pour le moment', 'Pas d''information pour le moment'),
--(7, 'Trou Weron', 'Trou du valon sec de Maillen', 00.00006, 00.00006, 750.00, 86.00, 'Pas d''information pour le moment', 'Pas d''information pour le moment'),
--(8, 'Trou Bernard', 'Trou majeur du valon sec de Maillen & Gouffre le plus profond de Belgique', 00.00007, 00.00007, 1400.00, 144.00, 'Pas d''information pour le moment', 'Pas d''information pour le moment'),
--(9, 'Puit-Aux-Lampes', 'Trou entre Jemelle et Rochefort & Parmi les plus grandes salles de Belgique', 00.00008, 00.00008, 520.00, 65.00, 'Pas d''information pour le moment', 'Pas d''information pour le moment'),
--(10, 'Trou de l''Eglise', 'Trou devant l''église de Mont', 00.00009, 00.00009, 1466.00, 110.00, 'Pas d''information pour le moment', 'Pas d''information pour le moment')
--Set Identity_insert Site off;