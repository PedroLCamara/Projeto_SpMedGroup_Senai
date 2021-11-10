import '../../Css/Home.css';
import ImgClinicasParceiras from '../../assets_/close-up-woman-writing.jpg';
import ImgMinhasConsultas from '../../assets_/woman-visiting-female-doctor.jpg';
import Footer from '../../Components/Footer/Footer.jsx';
import Header from '../../Components/Header/Header.jsx';
import {Link} from 'react-router-dom';

function App() {
    return (
        <div>
            <Header></Header>
            <main>
                <section class="Banner">
                    <div class="ContainerGrid ContainerBanner">
                        <h1>Administre suas consultas médicas de qualquer lugar!</h1>
                        <Link Link to="/Login" className="Link">Já é cadastrado? Entre!</Link>
                    </div>
                </section>
                <section class="ClinicasParceiras">
                    <div class="ContainerGrid ContainerClinicasParceiras">
                        <img src={ImgClinicasParceiras} class="ImagemClinicasParceiras" alt="Imagem da mesa de um consultório, com uma ficha médica sendo analisada por um doutor e um estetoscópio ao lado."></img>
                        <div class="QuadradoClinicasParceiras"></div>
                        <div class="BoxClinicasParceiras">
                            <p>Clínicas repletas de especialistas em qualquer lugar do Brasil. Consulte já nossas parceiras e
                                conheça seus profissionais e especialidades</p>
                            <a>Ir às clínicas parceiras</a>
                        </div>
                    </div>
                </section>
                <section class="Consultas">
                    <div class="ContainerGrid ContainerConsultas">
                        <div class="BoxConsultas">
                            <p>Acesse e administre suas consultas, futuras ou já realizadas em qualquer lugar e de qualquer lugar </p>
                            <a>Ir às minhas consultas</a>
                        </div>
                        <div class="QuadradoConsultas"></div>
                        <img src={ImgMinhasConsultas} class="ImagemConsultas" alt="Médica atendendo uma paciente em um consultório de clínica. Ambas estão felizes e em uma conversa amigável e prazerosa"></img>
                    </div>
                </section>
            </main>
            <Footer></Footer>
        </div>
    );
}

export default App;
