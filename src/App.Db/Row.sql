CREATE TABLE public."Row" (
           "Id" SERIAL,
    "CreatedAt" TIMESTAMPTZ  NOT NULL,
     "ModuleId" INT          NOT NULL,
         "Name" TEXT         NULL,
    "UpdatedAt" TIMESTAMPTZ  NOT NULL,
     CONSTRAINT "PK_Row"
    PRIMARY KEY ("Id"),

     CONSTRAINT "FK_Row_Module_ModuleId"
    FOREIGN KEY ("ModuleId")
     REFERENCES public."Module" ("Id"),

     CONSTRAINT "UQ_Site"
         UNIQUE ("SiteId")
);