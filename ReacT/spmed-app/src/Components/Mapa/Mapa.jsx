import { useState, useEffect } from "react";
import axios from 'axios';
import '../../Css/Administracao.css';
import Footer from '../../Components/Footer/Footer.jsx';
import Header from '../../Components/Header/Header.jsx';
import { Link, Navigate, useNavigate } from 'react-router-dom';
import { TokenConvertido, UsuarioAutenticado } from '../../Services/auth.js';
import { Wrapper, Status } from "@googlemaps/react-wrapper";

function MyMapComponent({
    center,
    zoom,
//   }: {
//     center: google.maps.LatLngLiteral;
//     zoom: number;
//   }) {
}){
    center = google.maps.LatLng;
    zoom = 15;

    const ref = useRef();
  
    useEffect(() => {
      new window.google.maps.Map(ref.current, {
        center,
        zoom,
      });
    });
  
    return <div ref={ref} id="map" />;
  }

export default function Mapa() {
    const [ListaLocalizacoes, setListaLocalizacoes] = useState([]);

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

    useEffect(PreencherLista, []);

    return(
        <div>

        </div>
    );
}