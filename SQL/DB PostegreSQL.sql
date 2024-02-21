CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

CREATE TABLE "WatchfullAcess" (
    "Id" uuid NOT NULL,
    "AccessTime" text NOT NULL,
    "Username" text NOT NULL,
    "Updates" integer NOT NULL,
    CONSTRAINT "PK_WatchfullAcess" PRIMARY KEY ("Id")
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240216224506_init', '7.0.16');

COMMIT;

START TRANSACTION;

CREATE TABLE "Configurations" (
    "Id" uuid NOT NULL,
    "LastSystemUpdate" text NOT NULL,
    "LastUpdate" text NOT NULL,
    "StatusDatabase" integer NOT NULL,
    CONSTRAINT "PK_Configurations" PRIMARY KEY ("Id")
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240217004203_add-configurations', '7.0.16');

COMMIT;

START TRANSACTION;

CREATE TABLE "OpenBanking" (
    "Id" uuid NOT NULL,
    "CustomerFriendlyName" text NOT NULL,
    "Favorite" boolean NOT NULL,
    CONSTRAINT "PK_OpenBanking" PRIMARY KEY ("Id")
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240218230347_add-openbanking-entity', '7.0.16');

COMMIT;

START TRANSACTION;

ALTER TABLE "Configurations" ADD "UpdateCycle" integer NOT NULL DEFAULT 0;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240219024026_update-configuration', '7.0.16');

COMMIT;

