CREATE TABLE public."Module" (
        "Id" SERIAL,
      "Name" TEXT NULL,
    "SiteId" INT  NOT NULL,
     CONSTRAINT "PK_Module" 
    PRIMARY KEY ("Id"),

     CONSTRAINT "FK_Module_Site_SiteId" 
    FOREIGN KEY ("SiteId") 
     REFERENCES public."Site" ("Id")
);