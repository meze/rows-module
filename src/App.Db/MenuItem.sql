CREATE TABLE public."MenuItem" (
                  "Id" SERIAL,
    "DisplayOnDesktop" BOOLEAN NOT NULL,
     "DisplayOnMobile" BOOLEAN NOT NULL,
                "Link" TEXT    NULL,
              "MenuId" INT     NULL,
                "Path" TEXT    NULL,
            "Sequence" INT     NOT NULL,
                "Type" INT     NOT NULL,
            CONSTRAINT "PK_MenuItem"
           PRIMARY KEY ("Id"),

            CONSTRAINT "FK_MenuItem_Menu_MenuId"
           FOREIGN KEY ("MenuId")
            REFERENCES public."Menu" ("Id")
);