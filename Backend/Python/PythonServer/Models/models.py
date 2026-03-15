from sqlmodel import SQLModel, Field
from typing import Optional


class Hiba(SQLModel, table=True):
    id: Optional[int] = Field(default=None, primary_key=True)
    gyarto: str
    hibakod: str
    hibaktsg: int
    hibadatum: str
    javaId: Optional[int] = Field(default=None)

class Javitas(SQLModel, table=True):
    id: Optional[int] = Field(default=None, primary_key=True)
    hibaid: Optional[int] = Field(default=None)
    javaId: Optional[int] = Field(default=None)
    szerelo: str
    datum: str
    javitasktsg: int
    munkaber: int
    nyereseg: int

class Naplo(SQLModel, table=True):
    id: Optional[int] = Field(default=None, primary_key=True)
    csharpId: Optional[int] = Field(default=None)
    gep: str
    szerelo: str
    hibakod: str
    javitasktsg: int
    datum: str

