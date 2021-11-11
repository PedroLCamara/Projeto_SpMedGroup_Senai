import React, { Component } from 'react';
import { useState, useEffect } from "react";
import axios from 'axios';

export default function ImagemPerfil() {
    const [ImgPerfil, setImg] = useState(null);

    function BuscarImg() {
        axios('http://localhost:5000/api/Perfis', {
            headers: {
                Authorization: 'Bearer ' + localStorage.getItem('usuario-login'),
            },
        })
            .then((resposta) => {
                if (resposta.status === 200) {
                    setImg(resposta.data)
                }
            })
            .catch((erro) => console.log(erro))
    }

    useEffect(BuscarImg, []);

    return (
        <img src={'data:image;base64,' + ImgPerfil}></img>
    )
}