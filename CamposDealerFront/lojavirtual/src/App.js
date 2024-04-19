import './App.css';

import 'bootstrap/dist/css/bootstrap.min.css';
import axios from 'axios';

import { Modal, ModalBody, ModalFooter, ModalHeader } from 'reactstrap';
import React, { useState, useEffect } from 'react';

function App() {

  const clienteUrl = "https://localhost:7019/ClienteController/GetCliente";
  // const produtoUrl = "https://localhost:7019/ProdutoController/GetProduto";
  // const vendaUrl = "https://localhost:7019/VendasController/GetVendas";

  const [dataCLiente, setdataCLiente] = useState([]);
  // const [dataProduto, setDataProduto] = useState([]);
  // const [dataVenda, setDataVenda] = useState([]);

  // /ClienteController/GetCliente

 const pedidosGet = async () => {
  try {
    const response = await axios.get(clienteUrl);
    // Verifica se a resposta foi bem-sucedida (status 200)
    if (response.status === 200) {
      // Acessa os dados diretamente através da propriedade 'data'
      const responseData = response.data;
      
      // Verifica se a resposta contém os dados esperados (array de clientes, por exemplo)
      if (Array.isArray(responseData)) {
        // Define os dados recebidos como dataCliente
        setdataCLiente(responseData);
      } else {
        console.error("Data returned from server is not an array:", responseData);
      }
    } else {
      console.error("Failed to fetch data. Status:", response.status);
    }
  } catch (error) {
    console.log(error);
  }
}




  useEffect(() => {
    pedidosGet();

  })

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
            {dataCLiente.map(cliente => (
              <tr key={cliente.id}>
                <td>{cliente.id}</td>

              </tr>
            ))}
           
          </tbody>
        </table>
      </div>

      
    </div>
  );
}

export default App;
