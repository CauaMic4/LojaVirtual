import './App.css';

import 'bootstrap/dist/css/bootstrap.min.css';
import axios, { Axios } from "axios";

import { Modal, ModalBody, ModalFooter, ModalHeader } from 'reactstrap';
import React, { useState, useEffect } from 'react';

function App() {

  const baseUrl = "https://localhost:7019/ClienteController/GetCliente";
  const baseUrl2 = "https://localhost:7019/ProdutoController/GetProduto";
  const baseUrl3 = "https://localhost:7019/VendasController/GetVendas";

  const [data, setData] = useState([]);
  // const [data2, setData2] = useState([]);
  // const [data3, setData3] = useState([]);

  const pedidoGet = async () => {
    await axios.get(baseUrl)
      .then(response => {
        setData(response.data);
      }).catch(error => {
        console.log(error)
      })
  };

  const produtoGet = async () => {
    await axios.get(baseUrl2)
      .then(response => {
        setData(response.data2);
      }).catch(error => {
        console.log(error)
      })
  };

const vendaGet = async () => {
    await axios.get(baseUrl3)
      .then(response => {
        setData(response.data3);
      }).catch(error => {
        console.log(error)
      })
  };

  useEffect(() => {
    pedidoGet();
    produtoGet();
    vendaGet();
  }, [data])

  return (
    <div className='cliente-container container'>
      <br/>
      <h3>Loja Virtual</h3>
      
      <div className='first-table '>
        <h2>Tabelas com os dados das API´s</h2>
        <h4>Tabela Clientes</h4>
        <header className='header'>
          
          <button className='btn btn-success'>Incluir novo Cliente</button>
        </header>
        <table className='table table-bordered'>
          <thead>
            <tr >
              <th className='headers'>Id</th>
              <th className='headers'>Nome</th>
              <th className='headers'>Cidade</th>
              <th className='headers'>Operação</th>
            </tr>
          </thead>
          <tbody>
            {Array.isArray(data) && data.map(cliente => (
              <tr key={cliente.idCliente}>
                <td>{cliente.idCliente}</td>
                <td>{cliente.nmCliente }</td>
                <td>{cliente.Cidade}</td>
                <td>
                  <button className='btn btn-success'>Editar</button>
                  <button className='btn btn-danger'>Deletar</button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>

      <div className='first-table '>
        <h4>Tabela Produto</h4>
        <header className='header'>
          
          <button className='btn btn-success'>Incluir novos produtos</button>
        </header>
        <table className='table table-bordered'>
          <thead>
            <tr >
              <th className='headers'>Id</th>
              <th className='headers'>Nome</th>
              <th className='headers'>Cidade</th>
              <th className='headers'>Operação</th>
            </tr>
          </thead>
          <tbody>
              {Array.isArray(data) && data.map(product => (
              <tr key={product.idProduto}>
                <td>{product.idProduto}</td>
                <td>{product.dscProduto }</td>
                <td>{product.vlrUnitario}</td>
                <td>
                  <button className='btn btn-success'>Editar</button>
                  <button className='btn btn-danger'>Deletar</button>
                </td>
                </tr>
              ))}
          </tbody>
        </table>
      </div>

      <div className='first-table '>
        <h4>Tabela Vendas</h4>
        <header className='header'>
          
          <button className='btn btn-success'>Incluir novas vendas</button>
        </header>
        <table className='table table-bordered'>
          <thead>
            <tr >
              <th className='headers'>Id</th>
              <th className='headers'>Nome</th>
              <th className='headers'>Cidade</th>
              <th className='headers'>Operação</th>
            </tr>
          </thead>
          <tbody>
              {Array.isArray(data) && data.map(sell => (
              <tr key={sell.idVenda}>
                <td>{sell.idVenda}</td>
                <td>{sell.dthVenda }</td>
                <td>{sell.idCliente}</td>
                <td>{sell.qtdVenda}</td>
                <td>{sell.vlrUnitarioVenda}</td>
                <td>
                  <button className='btn btn-success'>Editar</button>
                  <button className='btn btn-danger'>Deletar</button>
                </td>
                </tr>
              ))}
          </tbody>
        </table>
      </div>
    </div>
  );
}

export default App;
