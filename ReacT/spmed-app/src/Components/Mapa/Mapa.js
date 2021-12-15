import { useState, useEffect, useRef } from "react";
import axios from 'axios';
import { Link, Navigate, useNavigate } from 'react-router-dom';
import GoogleMapReact from 'google-map-react';

const AnyReactComponent = () => <div><h1>Teste yayyy</h1></div>;

export default function Mapa() {
    const [ListaLocalizacoes, setListaLocalizacoes] = useState([]);
    const Center = {
        lat: -21.292246,
        lng: -50.342843
    }
    const Zoom = 11;

    function PreencherLista() {
        axios('http://192.168.6.108:5000/api/Localizacoes', {
            headers: {
                Authorization: 'Bearer ' + localStorage.getItem('usuario-login'),
            },
        }).then((resposta) => {
            if (resposta.status === 200) {
                setListaLocalizacoes(resposta.data);
            }
        }).catch((erro) => {
            localStorage.removeItem('usuario-login');
            Navigate('/Login')
        })
    }

    useEffect(async () => {
        PreencherLista();
    });

    return (
        <div style={{ height: '400px', width: '100%' }}>
            <GoogleMapReact
                bootstrapURLKeys={{ key: 'AIzaSyD2iqvlmpETB-L0AYbikStCEEBj9zhHU5A' }}
                defaultCenter={Center}
                defaultZoom={Zoom}
            >
                {
                    ListaLocalizacoes.map((Localizacao) => {
                        <AnyReactComponent
                            lat={Localizacao.latitude}
                            lng={Localizacao.Longitude}
                        />
                    })
                }
            </GoogleMapReact>
        </div>
    );
}