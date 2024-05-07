<template>
    <div class="container">
        <h2 class="item_title">Informacion Clientes con sus Representantes de Ventas</h2>
        <table class="table table-dark">
            <thead>
                <tr>
                    <th scope="col">Código Cliente</th>
                    <th scope="col">Nombre Cliente</th>
                    <th scope="col">Telefono</th>
                    <th scope="col">Codigo Representante-Ventas</th>
                    <th scope="col">Nombre y Apellido Representante-Ventas</th>
                    <th scope="col">Codigo Oficina</th>
                    <th scope="col">Ciudad Oficina</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="(cliente, index) in clientesRepresentantesList" :key="index">
                    <td>{{ cliente.codigoCliente }}</td>
                    <td>{{ cliente.nombreCliente }}</td>
                    <td>{{ cliente.telefono }}</td>
                    <td>{{ cliente.codigoEmpleado }}</td>
                    <td>{{ cliente.nombreEmpleado }} {{ cliente.apellidoEmpleado }}</td>
                    <td>{{ cliente.codigoOficina }}</td>
                    <td>{{ cliente.ciudadOficina }}</td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
import axios from 'axios';
import Swal from 'sweetalert2';

export default {
    data() {
        return {
            clientesRepresentantesList: [],
            API_URL: process.env.VUE_APP_API_URL,
            API_IIS: process.env.VUE_APP_API_IIS
        };
    },
    mounted() {
        this.listClientesRepresentantes();
    },
    methods: {
        listClientesRepresentantes() {
            axios.get(this.API_IIS + '/api/Cliente/ClientesRepVentasOficinas', { withCredentials: true })
                .then(response => {
                    this.clientesRepresentantesList = response.data;
                })
                .catch(error => {
                    console.log("Error al mostrar la lista de ClientesRepresentantes ", error);
                    Swal.fire({
                        icon: 'error',
                        title: 'Error',
                        text: 'Ocurrió un error al mostrar la lista de ClientesRepresentantes. Por favor, inténtalo de nuevo más tarde.',
                        footer: `Detalles del error: ${error.message}`
                    });
                });
        }
    }
};
</script>

<style scoped></style>