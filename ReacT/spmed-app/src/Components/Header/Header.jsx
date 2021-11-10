import React, { Component } from 'react';
import {Link} from 'react-router-dom';
import Logo from '../../assets_/LogoPadrao.png'
import '../../Css/HeaderEFooter.css'

export default class Rodape extends Component {
    render() {
        return (
            <header>
                <div class="ContainerGrid ContainerHeader">
                    <Link to="/">
                        <img class="LogoHeader" src={Logo} alt="Logo da empresa SpMedicalGroup" />
                    </Link>
                    <nav class="NavHeader">
                        <Link to="/" class="LinkPaginaAtual">Início</Link>
                        <Link to="/" class="LinkPagina">Clínicas parceiras</Link>
                        <Link to="/" class="LinkPagina">Minhas Consultas</Link>
                        <Link to="/Login" class="LinkPagina">Login</Link>
                    </nav>
                </div>
            </header>
        )
    }
}