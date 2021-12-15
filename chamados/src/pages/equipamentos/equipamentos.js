import {Component} from 'react'
import api from '../../services/api'
import '../equipamentos/equip.css'
import {Link} from 'react-router-dom'

import logoSenai from "../../assets/img/logoSenai.png"
import pessoa from "../../assets/img/pessoa.png"
import painel from "../../assets/img/painel.png"
import agenda from "../../assets/img/agenda.png"
import equipamentos from '../../assets/img/equipamentos.png'
import configuracao from "../../assets/img/configuracao.png"
import sair from "../../assets/img/sair.png"
import home from "../../assets/img/home.png"
import fone from "../../assets/img/fone.png"
import axios from 'axios'
import painel2 from '../painel/painel'

export default class Equipamentos extends Component{
    constructor(props){
        super(props)
        this.state = {
            instituicao : 0,
            marca : '',
            numeroPatrimonio : '',
            tipoEquipamento: '',
            quantidade : '',
            listaTipoEquimentos : []
        }
    }

    componentDidMount(){

    }

    componentWillUnmount(){

    }

    sair = () => {
        localStorage.removeItem("token")
        this.props.history.push("/")
    }

     //chama a api com o método de cadastrar evento
     cadastrarEquipamento = (event) =>{
        //ignora o comportamento padrão do navegador
        event.preventDefault()

        this.setState({isLoading : true})

        //evento que recebe os dados do state
        //converte acesso para int, para que no back-end seja possivel cadastrar
        //pois o navegador envia o dado como string, e não da pra converter para bool implicitamente
        let equipamento ={
            //vem da api //state
            marca : this.state.marca,
            tipoEquipamento: this.state.tipoEquipamento,
            numeroPatrimonio : this.state.numeroPatrimonio,
            quantidade : this.state.quantidade
        }

        //define a url e o corpo da requisição
        axios.post('http://localhost:5000/api/Equipamentos', equipamento, {
            headers : {
                'Authorization' : `Bearer ${localStorage.getItem('token')}`
            }
        })

        //verifica o retorno da requisição

        .then(resposta => {
            //caso retorne 201
            if (resposta.status === 201) {
                
                //exibe no console do navegador a mensagem abaixo
                console.log('Equipamento cadastrado!')
                //define que a requisição terminou
                this.setState({isLoading : false})
            }
        })

        //se houver algum erro, é mostrado no console
        .catch(erro => {
            console.log(erro)
            
            //define que a requisição terminou
            this.setState({isLoading : false})
        })

        //atualiza a lista de eventos, sem o usuario precisar executar uma ação
        .then(this.buscarEventos)
    }

    //atualiza o state cada vez que há uma alteração no input
    atualizaState = async (campo) =>{
        await this.setState({ [campo.target.name] : campo.target.value})

    }

    render(){
        return(
            <main>
                <div class="sidebar">
                    <div class="center">
                        <menu>
                            <div class="senai">
                                <img src={logoSenai} alt="Senai"/>
                                <p>SEJA BEM VINDO!</p>
                            </div>
                            <div class="efeito user">
                                <img src={pessoa} alt="pessoa"/>
                                <h3>Marcos Vinicius</h3>
                                <p>Administrador do sistema</p>
                            </div>
                            <Link to = "/painel">
                                <div class="efeito painel">
                                    <img src={painel} alt="painel"/>
                                    <p>Painel de controle</p>
                                </div>
                            </Link>
                            <div class="efeito Agenda">
                                <img src={agenda} alt="agenda"/>
                                <p>Agenda</p>
                            </div>
                            <Link to ="/equipamentos">
                                <div class="efeito Equipamentos">
                                    <img src={equipamentos} alt="Equipamentos"/>
                                    <p>Equipamentos</p>
                                </div>
                            </Link>
                            <div class="efeito Configuracao">
                                <img src={configuracao} alt="configuracao"/>
                                <p>Configuração</p>
                            </div>
                            <div class="efeito Sair" onClick={this.sair}>
                                <img src={sair} alt="sair"/>
                                <p style={{color: "red"}}>Sair</p>
                            </div>
                        </menu>
                    </div>
                </div>
                <section class="conteudo">
                
                    <div class="center">
                        <h2>Cadastrar Equipamentos</h2>
                        <p style={{color: 'red', marginBottom: '2em'}}>Todos os campos abaixos são obrigatórios*</p>
                        <form onSubmit={this.cadastrarEquipamento}>
                            <div class="geral marca">
                                <label>Marca*</label>
                                <input 
                                placeholder="Ex: Dell" 
                                type="text"
                                name="marca"
                                
                                value={this.state.marca}

                                //chama a função para atualizar o state cada vez que há uma alteração no input
                                onChange={this.atualizaState}
                                style={{backgroundColor: '#B7B7B7', borderRadius: 3}}
                                />
                            </div>
                            <div class="geral t_equipamento">
                                <label
                                
                                >Tipo de equipamento</label>
                                <select
                                 style={{backgroundColor: '#B7B7B7', borderRadius: 3}}
                                 name="tipoEquipamento"
                                 value={this.state.tipoEquipamento}
                               >
                                    <option selected >Selecionado</option>
                                    <option value="1" required>PC</option>
                                    <option value="2" required>Notebook</option>
                                </select>
                            </div >
                            <div class="wrapper">
                                <div class="geral Patrimonio">
                                    <label>N de Patrimônio*</label>
                                    <input 
                                     //acesso livre
                                    name="numeroPatrimonio"
                                    value={this.state.numeroPatrimonio}

                                    //chama a função para atualizar o state cada vez que há uma alteração no input
                                    onChange={this.atualizaState}
                                    type="text"
                                    style={{backgroundColor: '#B7B7B7', borderRadius: 3}}/>
                                    
                                </div>
                                <div class="geral quantidade">
                                    <label>Quantidade</label>
                                    <input
                                    name="quantidade"
                                    value={this.state.quantidade}

                                    onChange={this.atualizaState}
                                    type="text"

                                    style={{backgroundColor: '#B7B7B7', borderRadius: 3}}
                                    />
                                </div>
                            </div>
                            <button type='submit' style={{fontSize: 12, width: '10em', height: '3em', borderRadius: 4}}>CADASTRAR</button>
                        </form>
                    </div>
                    <img src={fone}/>
                </section>
            </main>
        )
    }
}