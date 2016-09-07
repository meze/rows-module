CREATE TABLE public."RowValue" (
          "Id" SERIAL,
     "FieldId" INT  NULL,
       "RowId" INT  NULL,
       "Value" TEXT NULL,
     CONSTRAINT "PK_RowValue" 
    PRIMARY KEY ("Id"),

     CONSTRAINT "FK_RowValue_Field_FieldId" 
    FOREIGN KEY ("FieldId") 
     REFERENCES public."Field" ("Id"),

     CONSTRAINT "FK_RowValue_Row_RowId" 
    FOREIGN KEY ("RowId") 
     REFERENCES public."Row" ("Id")
);