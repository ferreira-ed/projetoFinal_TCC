import {parseJwt} from '../../services/auth';
import React, {Component} from 'react';
import api from '../../services/api';
import login from '../login/login.css';

import logo from '../../assets/img/logo senai.png'
import img from '../../assets/img/engenharia-de-producao.png'
import Cadastro from '../cadastro/cadastro';

class Login extends Component{
    constructor(props){
        super(props);
        this.state = {
            email : '',
            senha: ''
        }
    }

    login = async (event) => {

        event.preventDefault();

        //define a url e os parâmetros da requisição
         api.post('/login', {
            email : this.state.email,
            senha : this.state.senha
            
        })

        
        .then(resposta => {
            
            if(resposta.status === 200){
                localStorage.setItem('token', resposta.data.token)

                this.props.history.push('/')

                if (parseJwt().role === '4' || '1') {
                    this.props.history.push('/painel')
                    console.log('login realizado')
                }

                if(parseJwt().role === '5'){
                    this.props.history.push('/index')
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
                    <img class="img-side2" src={img}/>
                    <section  class="content-section2">
                        <form class="form2" onSubmit={this.login}>
                            <img class="logo2" src={logo}/>
                            <h2 class="texto-cadastro2">Faça seu login para acessar a plataforma</h2>
                            <p class="name-top2">Email</p>
                            <input
                                class="input-text2"
                                type='text' 
                                name='email'
                                value={this.state.email}
                                onChange={this.atualizaState}
                                placeholder='email@email.com'
                            />

                            <p class="name-top2">Senha</p>
                            <input
                                class="input-text2"
                                type='password' 
                                name='senha'
                                value={this.state.senha}
                                onChange={this.atualizaState}
                                placeholder = '* * * * * * * * *'
                        
                            />

                            <button class="button-logar2" type="submit">Acessar</button>
                            <p class="button-sub2">Não tem uma conta? <a href='/cadastro'>Cadastre-se</a></p>
                            
                        </form>
                    </section>
                </main>
            </div>

        )
    }
}

export default Login;