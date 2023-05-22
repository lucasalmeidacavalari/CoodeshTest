import './GridFileFormat.scss';
import { Tooltip as ReactTooltip } from 'react-tooltip'

export default function GridFileFormat() {
    return (<div className='file-format'>
        <h2>Formato do Arquivo</h2>
        <table>
            <thead>
                <tr>
                    <th>Campo</th>
                    <th>Início</th>
                    <th>Fim</th>
                    <th>Tamanho</th>
                    <th>Descrição</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>Tipo</td>
                    <td>1</td>
                    <td>1</td>
                    <td>1</td>
                    <td data-tooltip-content="1 - Venda produtor&#13;&#10; 2 - Venda afiliado&#13;&#10; 3 - Comissão paga&#13;&#10; 4 - Comissão recebida" data-tooltip-id="my-tooltip" className="tooltip-cell">
                        Tipo da transação
                    </td>
                </tr>
                <tr>
                    <td>Data</td>
                    <td>2</td>
                    <td>26</td>
                    <td>25</td>
                    <td>Data - ISO Date + GMT</td>
                </tr>
                <tr>
                    <td>Produto</td>
                    <td>27</td>
                    <td>56</td>
                    <td>30</td>
                    <td>Descrição do produto</td>
                </tr>
                <tr>
                    <td>Valor</td>
                    <td>57</td>
                    <td>66</td>
                    <td>10</td>
                    <td>Valor da transação em centavos</td>
                </tr>
                <tr>
                    <td>Vendedor</td>
                    <td>67</td>
                    <td>86</td>
                    <td>20</td>
                    <td>Nome do vendedor</td>
                </tr>
            </tbody>
        </table>
        <ReactTooltip id="my-tooltip" />
    </div>)
}