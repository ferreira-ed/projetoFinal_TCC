import {parseJwt} from '../../services/auth';
import React, {Component} from 'react';
import api from '../../services/api';

import logo from '../../assets/img/logo senai.png'
import img from '../../assets/img/engenharia-de-producao.png'

import Cadastroo from '../cadastro/cadastro.css'

class Cadastro extends Component{
    constructor(props){
        super(props);
        this.state = {
            email : '',
            senha: '',
            confirm: ''
        }
    }

    login = async (event) => {

        event.preventDefault();

        //define a url e os parâmetros da requisição
         api.post('/usuarios', {
            EmailUsuario : this.state.email,
            SenhaUsuario: this.state.senha,
        })

        
        .then(resposta => {
            
            if(resposta.status === 201){
                localStorage.setItem('token', resposta.data.token)

                this.props.history.push('/login')

                if (parseJwt().role === '2') {
                    this.props.history.push('/login')
                }

                if(parseJwt().role === '4'){
                    this.props.history.push('/login')
                }
                
            }
            console.log(this.state.email + ' ' +  this.state.senha)

    
        })

        .catch(erro => console.log(erro))
    }

    //atualizao state de acordo com o input
    atualizaState = async (campo) =>{
        await this.setState({ [campo.target.name] : campo.target.value})

    }

    render(){
        return(
            <div>
                <main>
                    <img class="img-side" src={img}/>
                    <section class="content-section">
                        <form class="form1" onSubmit={this.login} >
                            <img class="logo" src={logo} style={{width: 300, height: 89, marginBottom: '2em'}}/>
                            <h2 class="texto-cadastro">Faça seu cadastro para acessar a plataforma</h2>
                            <p class="name-top">Email</p>
                            <input
                                class="input-text"
                                type='text' 
                                name='email'
                                value={this.state.email}
                                onChange={this.atualizaState}
                                placeholder = 'email@email.com'
                            />

                            <p class="name-top">Senha</p>
                            <input
                                class="input-text"
                                type='password' 
                                name='senha'
                                value={this.state.senha}
                                onChange={this.atualizaState}
                                placeholder = '* * * * * * * * *'
                            />
                        
                            <button class="button-cadastrar" type="submit">Cadastrar</button>

                            <p class="button-sub">Ja tem uma conta? <a href = "login">Faça login</a></p> 
                        </form>
                    </section>
                </main>
            </div>

        )
    }
}

export default Cadastro;