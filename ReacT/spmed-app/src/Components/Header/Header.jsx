import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import Logo from '../../assets_/LogoPadrao.png'
import '../../Css/HeaderEFooter.css'
import { TokenConvertido, UsuarioAutenticado } from '../../Services/auth.js'
import ImgPerfil from '../PerfilFoto/PerfilFoto.jsx'

export default class Header extends Component {
    render() {
        if (UsuarioAutenticado() === false) {
            return (
                <header>
                    <div class="ContainerGrid ContainerHeader">
                        <Link to="/">
                            <img class="LogoHeader" src={Logo} alt="Logo da empresa SpMedicalGroup" />
                        </Link>
                        <nav class="NavHeader">
                            {
                                document.title === "SpMed - Home" ?
                                    <Link to="/" class="LinkPaginaAtual">Início</Link> : <Link to="/" class="LinkPagina">Início</Link>
                            }
                            <Link to="/Login" class="LinkPagina">Clínicas parceiras</Link>
                            <Link to="/Login" class="LinkPagina">Minhas Consultas</Link>
                            {
                                document.title === "SpMed - Login" ?
                                    <Link to="/Login" class="LinkPaginaAtual">Login</Link> : <Link to="/Login" class="LinkPagina">Login</Link>
                            }
                        </nav>
                    </div>
                </header>
            )
        }
        else if (TokenConvertido().Role === "1") {
            return (
                <header>
                    <div class="ContainerGrid ContainerHeader">
                        <Link to="/">
                            <img class="LogoHeader" src={Logo} alt="Logo da empresa SpMedicalGroup" />
                        </Link>
                        <nav class="NavHeader">
                            {
                                document.title === "SpMed - Home" ?
                                    <Link to="/" class="LinkPaginaAtual">Início</Link> : <Link to="/" class="LinkPagina">Início</Link>
                            }
                            <a class="LinkPagina">Clínicas</a>
                            <a class="LinkPagina">Consultas</a>
                            <a class="LinkPagina">Administração</a>
                            {
                                document.title === 'SpMed - Cadastro' ?
                                <Link to="/Cadastro" class="LinkPaginaAtual">Cadastro</Link> : <Link to="/Cadastro" class="LinkPagina">Cadastro</Link>
                            }
                            <Link to="/Perfil" class="LinkImagem"> <ImgPerfil></ImgPerfil> </Link>
                        </nav>
                    </div>
                </header>
            )
        }
        else if (TokenConvertido().Role === "2" || TokenConvertido().Role === "3") {
            return (
                <header>
                    <div class="ContainerGrid ContainerHeader">
                        <Link to="/">
                            <img class="LogoHeader" src={Logo} alt="Logo da empresa SpMedicalGroup" />
                        </Link>
                        <nav class="NavHeader">
                            {
                                document.title === "SpMed - Home" ?
                                    <Link to="/" class="LinkPaginaAtual">Início</Link> : <Link to="/" class="LinkPagina">Início</Link>
                            }
                            <a class="LinkPagina">Clínicas parceiras</a>
                            <a class="LinkPagina">Minhas Consultas</a>
                            <Link to="/Perfil" class="LinkImagem"> <ImgPerfil></ImgPerfil> </Link>
                        </nav>
                    </div>
                </header>
            )
        }
    }
}