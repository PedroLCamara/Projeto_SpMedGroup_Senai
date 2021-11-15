import { useState, useEffect } from "react";
import axios from 'axios';
import '../../Css/Consulta.css';
import Footer from '../../Components/Footer/Footer.jsx';
import Header from '../../Components/Header/Header.jsx';
import { Link, Navigate, useNavigate } from 'react-router-dom';
import { TokenConvertido, UsuarioAutenticado } from '../../Services/auth.js';

export default function Consultas(){
    document.title = "SpMed - Consultas";
}