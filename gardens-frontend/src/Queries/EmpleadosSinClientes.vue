<template>
    <div class="container">
        <h2 class="item_title">Empleados sin Clientes</h2>
        <table class="table table-dark">
            <thead>
                <tr>
                    <th scope="col">Código Empleado</th>
                    <th scope="col">Nombres y Apellidos</th>
                    <th scope="col">Puesto</th>
                    <th scope="col">Codigo Jefe</th>
                    <th scope="col">Nombres y Apellidos Jefe</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="(val, key) in empleadosSinClientesList" :key="key">
                    <td>{{ val.codigoEmpleado }}</td>
                    <td>{{ val.nombreEmpleado }} {{ val.apellidoEmpleado }}</td>
                    <td>{{ val.puestoEmpleado }}</td>
                    <td>{{ val.codigoJefe }}</td>
                    <td>{{ val.nombreJefe }} {{ val.apellidoJefe }}</td>
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
            empleadosSinClientesList: [],
            API_URL: process.env.VUE_APP_API_URL,
            API_IIS: process.env.VUE_APP_API_IIS
        };
    },
    mounted() {
        this.listEmpleadosSinClientes();
    },
    methods: {
        listEmpleadosSinClientes() {
            axios.get(this.API_IIS + '/api/Empleado/EmpleadosSinClientes', { withCredentials: true })
                .then(response => {
                    this.empleadosSinClientesList = response.data;
                })
                .catch(error => {
                    console.log("Error al mostrar la lista de EmpleadosSinClientes ", error);
                    Swal.fire({
                        icon: 'error',
                        title: 'Error',
                        text: 'Ocurrió un error al mostrar la lista de EmpleadosSinClientes. Por favor, inténtalo de nuevo más tarde.',
                        footer: `Detalles del error: ${error.message}`
                    });
                });
        }
    }
};
</script>

<style scoped>
/* Estilos específicos del componente si es necesario */
</style>