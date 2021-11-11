import { useState, useEffect } from "react";
import axios from 'axios';
import '../../Css/Perfil.css';
import Footer from '../../Components/Footer/Footer.jsx';
import Header from '../../Components/Header/Header.jsx';
import { useNavigate } from 'react-router-dom';
import { TokenConvertido, UsuarioAutenticado } from '../../Services/auth.js'
import ImgPerfil from '../../Components/PerfilFoto/PerfilFoto.jsx'

export default function Perfil() {
    const [Nome, setNome] = useState('');
    const [Email, setEmail] = useState('');
    const [Telefone, setTelefone] = useState('');
    const [Cpf, setCpf] = useState('');
    const [Idade, setIdade] = useState( 0 );
    const [Endereco, setEndereco] = useState('');
    const [Rg, setRg] = useState('');
    document.title = 'SpMed - Perfil';

    function CalcularIdade(DataDeNascimento) {
        let DataAtual = new Date();
        let Data = DataDeNascimento.split('T');
        let Ano = Data[0].split('-')[0];
        let Mes = Data[0].split('-')[1];
        let Dia = Data[0].split('-')[2];
        
        if (parseInt(Ano) >= DataAtual.getFullYear()) {
            return 0;
        }
        else if (parseInt(Mes) > DataAtual.getMonth()) {
            return (DataAtual.getFullYear() - parseInt(Ano)) - 1;
        }
        else if (parseInt(Mes) === DataAtual.getMonth()) {
            if (parseInt(Dia) <= DataAtual.getDay()) {
                return (DataAtual.getFullYear() - parseInt(Ano));
            }
            else {
                return (DataAtual.getFullYear() - parseInt(Ano)) - 1;
            }
        }
        else {
            return (DataAtual.getFullYear() - parseInt(Ano));
        }
    }

    function BuscarDados() {
        axios('http://localhost:5000/api/Usuarios/' + TokenConvertido().jti,
            {
                headers: {
                    Authorization: 'Bearer ' + localStorage.getItem('usuario-login'),
                },
            })
            .then((resposta) => {
                setNome(resposta.data.nome);
                setEmail(resposta.data.email);
                setIdade((CalcularIdade(resposta.data.dataDeNascimento)));
                if (resposta.data.paciente !== undefined) {
                    setTelefone(resposta.data.paciente.telefone);
                    setCpf(resposta.data.paciente.cpf);
                    setEndereco(resposta.data.paciente.endereco);
                    setRg(resposta.data.paciente.rg);
                }
                console.log(Idade);
            }
            )
    }

    useEffect(BuscarDados, [])

    return (
        <div>
            <Header></Header>
            <main class="MainPerfil">
                <section class="Perfil">
                    <div class="ContainerGrid ContainerPerfil">
                        <h1>{Nome}</h1>
                        <div class="InfosPerfil">
                            <ImgPerfil></ImgPerfil>
                            <div class="ColunaInfosPerfil">
                                <div class="CampoInfosPerfil">
                                    <h2>Email:</h2>
                                    <span>{Email}</span>
                                </div>
                                <div class="CampoInfosPerfil">
                                    <h2>Telefone:</h2>
                                    <span>telefone</span>
                                </div>
                                <div class="CampoInfosPerfil">
                                    <h2>CPF:</h2>
                                    <span>cpf</span>
                                </div>
                            </div>
                            <div class="ColunaInfosPerfil">
                                <div class="CampoInfosPerfil">
                                    <h2>Idade:</h2>
                                    <span>idade</span>
                                </div>
                                <div class="CampoInfosPerfil">
                                    <h2>Endereço:</h2>
                                    <span>endereco</span>
                                </div>
                                <div class="CampoInfosPerfil">
                                    <h2>RG:</h2>
                                    <span>rg</span>
                                </div>
                            </div>
                        </div>
                        <div class="LinksPerfil">
                            <a class="PerfilAltImg">Alterar Imagem de Perfil</a>
                            <a class="PerfilLogout">Logout</a>
                        </div>
                    </div>
                </section>
            </main>
            <Footer></Footer>
        </div>
    )
}