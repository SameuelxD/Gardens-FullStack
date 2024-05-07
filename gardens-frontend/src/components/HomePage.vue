<template>
    <div class="main-container">
        <h1 class="dashboard-title">Dashboard de Consultas</h1>
        <div class="query-selector">
            <label for="querySelect" class="querySelect">Seleccione una consulta:</label>
            <select id="querySelect" v-model="selectedQuery" @change="handleQuerySelection">
                <option value="">Seleccionar...</option>
                <option value="pagosPaypal2008">PagosPaypal2008</option>
                <option value="formasPagos">FormasPagos</option>
                <option value="clientesPagos">ClientesPagos</option>
                <option value="empleadosJefes">EmpleadosJefes</option>
                <option value="productosSinPedidos">ProductosSinPedidos</option>
                <option value="pedidosEstados">PedidosEstados</option>
                <option value="clientesSinPagos">ClientesSinPagos</option>
                <option value="clientesRepresentantes">ClientesRepresentantes</option>
                <option value="clientesRepresentantesSinPagos">ClientesRepresentantesSinPagos</option>
                <option value="pedidosIncumplidos">PedidosIncumplidos</option>
                <option value="oficinasUno">Oficinas1</option>
                <option value="productosMasVendidos">ProductosMasVendidos</option>
                <option value="productosFacturando">ProductosFacturando</option>
                <option value="productoMasVendido">ProductoMasVendido</option>
                <option value="clientesPedidos">ClientesPedidos</option>
                <option value="empleadosSinClientes">EmpleadosSinClientes</option>
                <!--<option value="oficinasDos">Oficinas2</option>  -->
                <!--<option value="clientesPedidosIncumplidos">ClientesPedidosIncumplidos</option> -->
                <option value="clientesProductosGamas">ClientesProductosGamas</option>
                <option value="repVentasSinClientes">RepVentasSinClientes</option>
            </select>
        </div>
        <div class="query-result">
            <component :is="selectedQueryComponent" v-if="selectedQueryComponent" :user-data="userData" />
        </div>
    </div>
</template>

<script>
import PagosPaypal2008 from '../Queries/PagosPaypal2008.vue';
import FormasPagos from '../Queries/FormasPagos.vue';
import ClientesPagos from '../Queries/ClientesPagos.vue';
import EmpleadosJefes from '../Queries/EmpleadosJefes.vue';
import ProductosSinPedidos from '../Queries/ProductosSinPedidos.vue';
import PedidosEstados from '../Queries/PedidosEstados.vue';
import ClientesSinPagos from '../Queries/ClientesSinPagos.vue';
import ClientesRepresentantes from '../Queries/ClientesRepresentantes.vue';
import ClientesRepresentanteSinPagos from '../Queries/ClientesRepresentantesSinPagos.vue';
import PedidosIncumplidos from '../Queries/PedidosIncumplidos.vue';
import OficinasUno from '../Queries/OficinasUno.vue';
import ProductosMasVendidos from '../Queries/ProductosMasVendidos.vue';
import ProductosFacturando from '../Queries/ProductosFacturando.vue';
import ProductoMasVendido from '../Queries/ProductoMasVendido.vue';
import ClientesPedidos from '../Queries/ClientesPedidos.vue';
import EmpleadosSinClientes from '../Queries/EmpleadosSinClientes.vue';
// import OficinasDos from '../Queries/OficinasDos.vue';
// import ClientesPedidosIncumplidos from '../Queries/ClientesPedidosIncumplidos.vue';
import ClientesProductosGamas from '../Queries/ClientesProductosGamas.vue';
import RepVentasSinClientes from '../Queries/RepVentasSinClientes.vue';

export default {
    data() {
        return {
            selectedQuery: ''
        };
    },
    computed: {
        selectedQueryComponent() {
            switch (this.selectedQuery) {
                case 'pagosPaypal2008':
                    return PagosPaypal2008;
                case 'formasPagos':
                    return FormasPagos;
                case 'clientesPagos':
                    return ClientesPagos;
                case 'empleadosJefes':
                    return EmpleadosJefes;
                case 'productosSinPedidos':
                    return ProductosSinPedidos;
                case 'pedidosEstados':
                    return PedidosEstados;
                case 'clientesSinPagos':
                    return ClientesSinPagos;
                case 'clientesRepresentantes':
                    return ClientesRepresentantes;
                case 'clientesRepresentantesSinPagos':
                    return ClientesRepresentanteSinPagos;
                case 'pedidosIncumplidos':
                    return PedidosIncumplidos;
                case 'oficinasUno':
                    return OficinasUno;
                case 'productosMasVendidos':
                    return ProductosMasVendidos;
                case 'productosFacturando':
                    return ProductosFacturando;
                case 'productoMasVendido':
                    return ProductoMasVendido;
                case 'clientesPedidos':
                    return ClientesPedidos;
                case 'empleadosSinClientes':
                    return EmpleadosSinClientes;
                // case 'oficinasDos':
                //  return OficinasDos;
                // case 'clientesPedidosIncumplidos':
                //  return ClientesPedidosIncumplidos;
                case 'clientesProductosGamas':
                    return ClientesProductosGamas;
                case 'repVentasSinClientes':
                    return RepVentasSinClientes;
                default:
                    return null;
            }
        }
    },
    methods: {
        handleQuerySelection(event) {
            this.selectedQuery = event.target.value;
        }
    }
};
</script>

<style scoped>
.main-container {
    width: 100%;
    height: 100%;
    display: flex;
    justify-content: center;
    align-items: center;
    flex-direction: column;
    /* Alineación vertical */
    padding: 20px;
    box-sizing: border-box;
}

.query-selector {
    margin-top: 20px;
}
</style>