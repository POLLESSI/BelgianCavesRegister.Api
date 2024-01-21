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

--INSERT INTO [Site] (Site_Name, Site_Description, Latitude, Longitude, [Length], Depth, AccessRequirement, PracticalInformation, DonneesLambda_Id, NOwner_Id, ScientificData_Id, Bibliography_Id) VALUES ('Trou d''Aquin', 'Trou près de Lustin', 00, 00, 4500, 56, 'Pas d''information pour le moment', 'Pas d''information pour le moment', 0, 0, 0, 0)
--INSERT INTO [Site] (Site_Name, Site_Description, Latitude, Longitude, [Length], Depth, AccessRequirement, PracticalInformation, DonneesLambda_Id, NOwner_Id, ScientificData_Id, Bibliography_Id) VALUES ('Grotte Ste Anne', 'Grotte entre Tilf et Esneux', 00, 00, 4500, 45, 'Pas d''information pour le moment', 'Pas d''information pour le moment', 0, 0, 0, 0)
--INSERT INTO [Site] (Site_Name, Site_Description, Latitude, Longitude, [Length], Depth, AccessRequirement, PracticalInformation, DonneesLambda_Id, NOwner_Id, ScientificData_Id, Bibliography_Id) VALUES ('Reseau Chawresse-Veronika', 'Trou au dessus de Tilf', 00, 00, 4000, 96, 'Pas d''information pour le moment', 'Pas d''information pour le moment', 0, 0, 0, 0)
--INSERT INTO [Site] (Site_Name, Site_Description, Latitude, Longitude, [Length], Depth, AccessRequirement, PracticalInformation, DonneesLambda_Id, NOwner_Id, ScientificData_Id, Bibliography_Id) VALUES ('Abime de Beaumont', 'Trou sur les hauteurs d''Esneux', 00, 00, 516, 96, 'Pas d''information pour le moment', 'Pas d''information pour le moment', 0, 0, 0, 0)
--INSERT INTO [Site] (Site_Name, Site_Description, Latitude, Longitude, [Length], Depth, AccessRequirement, PracticalInformation, DonneesLambda_Id, NOwner_Id, ScientificData_Id, Bibliography_Id) VALUES ('Trou de la Laide Fosse', 'Trou sur les hauteurs de Han-Sur-Lesse', 00, 00, 2500, 46, 'Pas d''information pour le moment', 'Pas d''information pour le moment', 0, 0, 0, 0)
--INSERT INTO [Site] (Site_Name, Site_Description, Latitude, Longitude, [Length], Depth, AccessRequirement, PracticalInformation, DonneesLambda_Id, NOwner_Id, ScientificData_Id, Bibliography_Id) VALUES ('Abime de Lesves', 'Trou majeur du valon sec de Lesves', 00, 00, 750, 86, 'Pas d''information pour le moment', 'Pas d''information pour le moment', 0, 0, 0, 0)
--INSERT INTO [Site] (Site_Name, Site_Description, Latitude, Longitude, [Length], Depth, AccessRequirement, PracticalInformation, DonneesLambda_Id, NOwner_Id, ScientificData_Id, Bibliography_Id) VALUES ('Trou Weron', 'Trou du valon sec de Maillen', 00, 00, 750, 86, 'Pas d''information pour le moment', 'Pas d''information pour le moment', 0, 0, 0, 0)
--INSERT INTO [Site] (Site_Name, Site_Description, Latitude, Longitude, [Length], Depth, AccessRequirement, PracticalInformation, DonneesLambda_Id, NOwner_Id, ScientificData_Id, Bibliography_Id) VALUES ('Trou Bernard', 'Trou majeur du valon sec de Maillen & Gouffre le plus profond de Belgique', 00, 00, 1400, 144, 'Pas d''information pour le moment', 'Pas d''information pour le moment', 0, 0, 0, 0)
--INSERT INTO [Site] (Site_Name, Site_Description, Latitude, Longitude, [Length], Depth, AccessRequirement, PracticalInformation, DonneesLambda_Id, NOwner_Id, ScientificData_Id, Bibliography_Id) VALUES ('Puit-Aux-Lampes', 'Trou entre Jemelle et Rochefort & parmi les plus grandes salles de Belgique', 00, 00, 520, 65, 'Pas d''information pour le moment', 'Pas d''information pour le moment', 0, 0, 0, 0)
--INSERT INTO [Site] (Site_Name, Site_Description, Latitude, Longitude, [Length], Depth, AccessRequirement, PracticalInformation, DonneesLambda_Id, NOwner_Id, ScientificData_Id, Bibliography_Id) VALUES ('Trou de l''Eglise', 'Trou devant l''église de Mont', 00, 00, 1466, 110, 'Pas d''information pour le moment', 'Pas d''information pour le moment', 0, 0, 0, 0)
