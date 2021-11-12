import { useState, useEffect } from "react";
import axios from 'axios';
import '../../Css/CadastroUsuario.css';
import Footer from '../../Components/Footer/Footer.jsx';
import Header from '../../Components/Header/Header.jsx';
import { Navigate, useNavigate } from 'react-router-dom';
import { TokenConvertido, UsuarioAutenticado } from '../../Services/auth.js'

export default function Cadaastro() {
    document.title = 'SpMed - Cadastro';
    const [ListaUsuario, setListaUsuario] = useState([]);
    const [ListaTipoUsuario, setListaTipoUsuario] = useState([]);
    const [ListaClinica, setListaClinica] = useState([]);
    const [ListaEspecialidade, setListaEspecialidade] = useState([]);
    const [ListaPaciente, setListaPaciente] = useState([]);
    const [ListaMedico, setListaMedico] = useState([]);
    const [Email, setEmail] = useState('');
    const [Senha, setSenha] = useState('');
    const [Nome, setNome] = useState('');
    const [Nascimento, setNascimeto] = useState('');
    const [RG, setRg] = useState('');
    const [Cpf, setCpf] = useState('');
    const [Telefone, setTelefone] = useState('');
    const [Endereco, setEndereco] = useState('');
    const [IdCrm, setCrm] = useState(0);
    const [IdEspecialidade, setIdEspecialidade] = useState(0);
    const [IdClinica, setClinica] = useState(0);

function PreencherListas() {
    axios('http://localhost:5000/api/Usuarios', {
        headers: {
            Authorization: 'Bearer ' + localStorage.getItem('usuario-login'),
        },
    }).then( (resposta) => {
        setListaUsuario(resposta.data);
    })
    .catch( (erro) => console.log(erro));

    axios('http://localhost:5000/api/TiposUsuarios', {
        headers: {
            Authorization: 'Bearer ' + localStorage.getItem('usuario-login'),
        },
    }).then( (resposta) => {
        setListaTipoUsuario(resposta.data);
    })
    .catch( (erro) => console.log(erro));

    axios('http://localhost:5000/api/Clinicas')
    .then( (resposta) => {
        setListaClinica(resposta.data);
    })
    .catch((erro) => console.log(erro));

    axios('http://localhost:5000/api/Especialidades', {
        headers: {
            Authorization: 'Bearer ' + localStorage.getItem('usuario-login'),
        },
    }).then( (resposta) => setListaEspecialidade(resposta.data))
    .catch((erro) => console.log(erro));

    axios('http://localhost:5000/api/Pacientes', {
        headers: {
            Authorization: 'Bearer ' + localStorage.getItem('usuario-login'),
        },
    }).then( (resposta) => setListaPaciente(resposta.data))
    .catch((erro) => console.log(erro));

    axios('http://localhost:5000/api/Medicos', {
        headers: {
            Authorization: 'Bearer ' + localStorage.getItem('usuario-login'),
        },
    }).then( (resposta) => setListaMedico(resposta.data))
    .catch((erro) => console.log(erro));
}

    useEffect(PreencherListas, []);

    return (
        <div>
            <Header></Header>
            <main class="CadastroMain">
                <section class="CadastroUsuario">
                    <div class="ContainerGrid ContainerCadastro">
                        <h1>Cadastrar Usuário</h1>
                        <form>
                            <div class="LinhaFormCadastro">
                                <div class="CampoCadastro">
                                    <label>Email</label>
                                    <input type="email" />
                                </div>
                                <div class="CampoCadastro">
                                    <label>Senha</label>
                                    <input type="password" />
                                </div>
                            </div>
                            <div class="LinhaFormCadastro">
                                <div class="CampoCadastro">
                                    <label>Nome</label>
                                    <input type="text" />
                                </div>
                                <div class="CampoCadastro">
                                    <label>Data de nascimento</label>
                                    <input type="date" />
                                </div>
                            </div>
                            <div class="CampoCadastro">
                                <label>Tipo de usuário</label>
                                <select>
                                    <optgroup>
                                        <option value="0">Selecione um tipo de usuário</option>
                                        {ListaTipoUsuario.map((TipoUsuario) => {
                                            return(
                                                <option value={TipoUsuario.idTipoUsuario}>{TipoUsuario.tituloTipoUsuario}</option>
                                            )
                                        })}
                                    </optgroup>
                                </select>
                            </div>
                            <div class="BoxBotaoCadastro">
                                <button type="submit">Cadastrar</button>
                                <a>Já possui uma conta? Entre aqui</a>
                            </div>
                        </form>
                    </div>
                </section>
                <section class="CadastroPaciente">
                    <div class="ContainerGrid ContainerCadastro">
                        <h1>Cadastrar Paciente</h1>
                        <form>
                            <div class="LinhaFormCadastro">
                                <div class="CampoCadastro">
                                    <label>RG</label>
                                    <input type="text" />
                                </div>
                                <div class="CampoCadastro">
                                    <label>CPF</label>
                                    <input type="text" />
                                </div>
                            </div>
                            <div class="LinhaFormCadastro">
                                <div class="CampoCadastro">
                                    <label>Telefone</label>
                                    <input type="text" />
                                </div>
                                <div class="CampoCadastro">
                                    <label>Endereco</label>
                                    <input type="text" />
                                </div>
                            </div>
                            <div class="CampoCadastro">
                                <label>Usuário</label>
                                <select>
                                    <optgroup>
                                        <option value="0">Selecione um usuário disponível</option>
                                        {
                                            ListaUsuario.filter( (Usuario) => {
                                                return Usuario.idTipoUsuario === 3
                                            }).filter( (Usuario) => {
                                                return Usuario.idUsuario !== ListaUsuario.idUsuario
                                            }).map( (Usuario) => {
                                                return(
                                                    <option value={Usuario.idUsuario}>{Usuario.email}</option>
                                                )
                                            })
                                        }
                                    </optgroup>
                                </select>
                            </div>
                            <div class="BoxBotaoCadastro">
                                <button type="submit">Cadastrar</button>
                                <a>Já possui uma conta? Entre aqui</a>
                            </div>
                        </form>
                    </div>
                </section>
                <section class="CadastroMedico">
                    <div class="ContainerGrid ContainerCadastro">
                        <h1>Cadastrar Médico</h1>
                        <form>
                            <div class="LinhaFormCadastro">
                                <div class="CampoCadastro">
                                    <label>CRM</label>
                                    <input type="text" />
                                </div>
                                <div class="CampoCadastro">
                                    <label>Especialidade</label>
                                    <select>
                                        <optgroup>
                                            {
                                                ListaEspecialidade.map( (Especialidade) => {
                                                    <option value={Especialidade.idEspecialidade}>{Especialidade.nome}</option>
                                                })
                                            }
                                        </optgroup>
                                    </select>
                                </div>
                            </div>
                            <div class="LinhaFormCadastro">
                                <div class="CampoCadastro">
                                    <label>Clínica</label>
                                    <select></select>
                                </div>
                                <div class="CampoCadastro">
                                    <label>Usuário</label>
                                    <select></select>
                                </div>
                            </div>
                            <div class="BoxBotaoCadastro">
                                <button type="submit">Cadastrar</button>
                                <a>Já possui uma conta? Entre aqui</a>
                            </div>
                        </form>
                    </div>
                </section>
            </main>
            <Footer></Footer>
        </div>
    )
}