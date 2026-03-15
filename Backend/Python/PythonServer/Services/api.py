import os
import pandas as pd
from flask import Flask, request, jsonify
from sqlmodel import Session


from Models.models import Javitas, Naplo, Hiba
from Data.data import tablak_letrehozasa, engine

app = Flask(__name__)

with app.app_context():
    tablak_letrehozasa()



@app.route('/hiba', methods=['POST'])
def hiba_mentese():


    bejovo_adatok = request.get_json()

    if not bejovo_adatok:
        return jsonify("Nem érkezett adat!"), 400


    with Session(engine) as session:


        for sor in bejovo_adatok:
            uj_hiba = Hiba(**sor)
            session.add(uj_hiba)

        session.commit()

    dp = pd.DataFrame(bejovo_adatok)

    print(f"A kapot fálj beolvasva")

    filename = "hibak.csv"
    fajl_letezik = os.path.isfile(filename)

    dp.to_csv(filename,
        mode='a',
        index=False,
        sep=';',
        encoding='utf-8-sig',
        header=not fajl_letezik)


    return jsonify("Sikeresen elmentve az SQLite-ba és a CSV-be is!"), 200


@app.route('/javit', methods=['POST'])
def javit_mentese():


    bejovo_adatok = request.get_json()

    if not bejovo_adatok:
        return jsonify("Nem érkezett adat!"), 400


    with Session(engine) as session:


        for sor in bejovo_adatok:
            uj_javit = Javitas(**sor)
            session.add(uj_javit)

        session.commit()

    dp = pd.DataFrame(bejovo_adatok)

    print(f"A kapot fálj beolvasva")

    filename = "javitas.csv"
    fajl_letezik = os.path.isfile(filename)

    dp.to_csv(filename,
        mode='a',
        index=False,
        sep=';',
        encoding='utf-8-sig',
        header=not fajl_letezik)


    return jsonify("Sikeresen elmentve az SQLite-ba és a CSV-be is!"), 200

@app.route('/naplo', methods=['POST'])
def naplo_mentese():


    bejovo_adatok = request.get_json()

    if not bejovo_adatok:
        return jsonify("Nem érkezett adat!"), 400


    with Session(engine) as session:


        for sor in bejovo_adatok:
            uj_naplo = Naplo(**sor)
            session.add(uj_naplo)

        session.commit()

    dp = pd.DataFrame(bejovo_adatok)

    print(f"A kapot fálj beolvasva")

    filename = "naplo.csv"
    fajl_letezik = os.path.isfile(filename)

    dp.to_csv(filename,
        mode='a',
        index=False,
        sep=';',
        encoding='utf-8-sig',
        header=not fajl_letezik)


    return jsonify("Sikeresen elmentve az SQLite-ba és a CSV-be is!"), 200


