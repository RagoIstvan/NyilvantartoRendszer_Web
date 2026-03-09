
import pandas as pd
from flask import Flask, request, jsonify


app=Flask(__name__)


@app.route('/hibak',methods=['POST'])
def receive_failsdata():
    try:
        adat=request.json

        if not adat:
            return jsonify("Hiba a vmi nem jól müködik kód: 400"),400

        dp=pd.DataFrame(adat)

        print(f"A kapot fálj beolvasva")

        filename="hibak.csv"
        dp.to_csv(filename,index=False,sep=';',encoding='utf-8-sig')


        print(f"A kapot fálj csv-be kiirva")

        return jsonify("Sikeres fálj fogadás és csv-be irás"),200

    except Exception as e:
        print(f"{e}")
        return  jsonify("Hibakód: 500"),500

if __name__=='__main__':
    app.run(host='0.0.0.0',port=5000,debug=True)

