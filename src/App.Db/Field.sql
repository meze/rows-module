CREATE TABLE public."Field" (
           "Id" SERIAL,
        "Label" TEXT NULL,
     "ModuleId" INT  NOT NULL,
         "Name" TEXT NULL,
         "Type" TEXT NULL,
     CONSTRAINT "PK_Field"
    PRIMARY KEY ("Id"),

     CONSTRAINT "FK_Field_Module_ModuleId"
    FOREIGN KEY ("ModuleId")
     REFERENCES public."Module" ("Id")
);