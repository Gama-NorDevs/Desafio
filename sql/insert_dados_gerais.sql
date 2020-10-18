/*Script para inserção de dados*/
USE nordtv
/*Inserir Admin*/
/*
INSERT INTO 
                                  [dbo].[User] (name, 
                                        email, 
                                        password, 
                                        profile) 
                               VALUES ('Carlos', 
                                        'carlos@gmail.com',
                                        'carlos1234', 
                                        'ADMIN');
*/
/*Inserir o genero*/
/*
INSERT INTO [dbo].[Genre] (DESCRIPTION)
VALUES('Drama');

INSERT INTO [dbo].[Genre] (DESCRIPTION)
VALUES('Comédia');

INSERT INTO [dbo].[Genre] (DESCRIPTION)
VALUES('Suspense');

INSERT INTO [dbo].[Genre] (DESCRIPTION)
VALUES('Terror');*/
/*Inserir user's*/
/*
INSERT INTO 
                                  [dbo].[User] (name, 
                                        email, 
                                        password, 
                                        profile) 
                               VALUES ('Noé', 
                                        'noe@gmail.com',
                                        'noe1234', 
                                        'ACTOR');
INSERT INTO 
                                  [dbo].[User] (name, 
                                        email, 
                                        password, 
                                        profile) 
                               VALUES ('Icaro', 
                                        'icaro@gmail.com',
                                        'icaro1234', 
                                        'ACTOR');
INSERT INTO 
                                  [dbo].[User] (name, 
                                        email, 
                                        password, 
                                        profile) 
                               VALUES ('Mona', 
                                        'mona@gmail.com',
                                        'mona1234', 
                                        'ACTOR');
select * from [dbo].[User]
*/

/*Inserir Actor's*/
/*
INSERT INTO 
                                    [dbo].[Actor] 
                                    (  
                                    amount, 
                                    sex, 
                                    id_user)
                                VALUEs (   
                                        100,
                                        'M',           
                                        2
                                        )
INSERT INTO 
                                    [dbo].[Actor] 
                                    (  
                                    amount, 
                                    sex, 
                                    id_user)
                                VALUEs (   
                                        500,
                                        'M',           
                                        3
                                        )
INSERT INTO 
                                    [dbo].[Actor] 
                                    (  
                                    amount, 
                                    sex, 
                                    id_user)
                                VALUEs (   
                                        300,
                                        'F',           
                                        4
                                        )
select * from [dbo].[Actor]
*/

/*Insert tabela relação de actor e genre*/
/*INSERT INTO 
                                        [dbo].[Actor_Genre] (id_actor, id_genre) 
                                            VALUES ( 3, 4)
INSERT INTO 
                                        [dbo].[Actor_Genre] (id_actor, id_genre) 
                                            VALUES ( 3, 2)
INSERT INTO 
                                        [dbo].[Actor_Genre] (id_actor, id_genre) 
                                            VALUES ( 4, 4)
INSERT INTO 
                                        [dbo].[Actor_Genre] (id_actor, id_genre) 
                                            VALUES ( 4, 3)
INSERT INTO 
                                        [dbo].[Actor_Genre] (id_actor, id_genre) 
                                            VALUES ( 4, 1)		
INSERT INTO 
                                        [dbo].[Actor_Genre] (id_actor, id_genre) 
                                            VALUES ( 5, 4)
INSERT INTO 
                                        [dbo].[Actor_Genre] (id_actor, id_genre) 
                                            VALUES ( 5, 2)
INSERT INTO 
                                        [dbo].[Actor_Genre] (id_actor, id_genre) 
                                            VALUES ( 5, 1)
select * from [dbo].[Actor]
select * from [dbo].[Actor_Genre]
select * from [dbo].[Genre]
*/


/*Insert do work*/
/*INSERT INTO 
                                  [dbo].[Work] (Name, 
                                        budget, 
                                        date_start, 
                                        date_end,
                                        id_admin,
                                        id_genre) 
                               VALUES ('A saga do NordTv', 
                                        2000,
                                        '2020/11/08', 
                                        '2020/12/08',
                                        1,
                                        4)

INSERT INTO 
                                  [dbo].[Work] (Name, 
                                        budget, 
                                        date_start, 
                                        date_end,
                                        id_admin,
                                        id_genre) 
                               VALUES ('A saga do NordTv 2', 
                                        8000,
                                        '2021/01/08', 
                                        '2021/02/08',
                                        1,
                                        4)
INSERT INTO 
                                  [dbo].[Work] (Name, 
                                        budget, 
                                        date_start, 
                                        date_end,
                                        id_admin,
                                        id_genre) 
                               VALUES ('Novela do NordTv', 
                                        8000,
                                        '2020/12/01', 
                                        '2021/04/18',
                                        1,
                                        3)
INSERT INTO 
                                  [dbo].[Work] (Name, 
                                        budget, 
                                        date_start, 
                                        date_end,
                                        id_admin,
                                        id_genre) 
                               VALUES ('De repente NordTv', 
                                        500,
                                        '2021-05-03', 
                                        '2021-08-06',
                                        1,
                                        1)
*/

/*Insert na tabela de relação Actor_Work*/
/*
INSERT INTO 
                                        [dbo].[Actor_Work] (id_actor, id_work) 
                                            VALUES ( 3, 1); 
INSERT INTO 
                                        [dbo].[Actor_Work] (id_actor, id_work) 
                                            VALUES ( 4, 1); 
INSERT INTO 
                                        [dbo].[Actor_Work] (id_actor, id_work) 
                                            VALUES ( 5, 1); 
INSERT INTO 
                                        [dbo].[Actor_Work] (id_actor, id_work) 
                                            VALUES ( 3, 2); 
INSERT INTO 
                                        [dbo].[Actor_Work] (id_actor, id_work) 
                                            VALUES ( 4, 2); 
INSERT INTO 
                                        [dbo].[Actor_Work] (id_actor, id_work) 
                                            VALUES ( 5, 2); 
INSERT INTO 
                                        [dbo].[Actor_Work] (id_actor, id_work) 
                                            VALUES ( 4, 3); 
INSERT INTO 
                                        [dbo].[Actor_Work] (id_actor, id_work) 
                                            VALUES ( 5, 1); 
INSERT INTO 
                                        [dbo].[Actor_Work] (id_actor, id_work) 
                                            VALUES ( 4, 1); 
*/