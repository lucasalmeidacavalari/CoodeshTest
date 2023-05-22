import axios from 'axios';

export async function processFileContent(content, apiUrl) {
    let sellerExist;
    let productExist;
    const lines = content.split('\n');

    for (let i = 0; i < lines.length; i++) {
        const linha = lines[i];

        // 1º Intervalo: Início 1 e Fim 1
        const type = parseInt(linha.slice(0, 1));

        // 2º Intervalo: Início 2 e Fim 26
        const date = linha.slice(1, 26);

        // 3º Intervalo: Início 27 e Fim 56
        const product = linha.slice(26, 56);

        // 4º Intervalo: Início 57 e Fim 66
        const price = parseInt(linha.slice(56, 66));

        // 5º Intervalo: Início 67 e Fim 86
        const seller = linha.slice(66, 86);

        try {
            if (type === 1) {
                let data = await axios.get(apiUrl + '/Creator/' + seller);
                if (!data.data) {
                    data = await axios.post(apiUrl + '/Creator', { Name: seller });
                }
                sellerExist = data.data;
            } else {
                let data = await axios.get(apiUrl + '/Affiliated/' + seller);
                if (!data.data) {
                    data = await axios.post(apiUrl + '/Affiliated', { Name: seller });
                }
                sellerExist = data.data;
            }
        } catch (error) {
            console.error(error);
        }
        try {
            let data = await axios.get(apiUrl + '/Product/' + product);
            if (!data.data) {
                data = await axios.post(apiUrl + '/Product', { Name: product });
            }
            productExist = data.data;
        } catch (error) {
            console.error(error);
        }
        try {
            if (type === 1) {
                await axios.post(apiUrl + '/Transaction', { DateTransaction: date, Price: price, Type: type, CreatorId: sellerExist.creatorId, ProductId: productExist.productId })
            } else if (type === 2) {
                await axios.post(apiUrl + '/Transaction', { DateTransaction: date, Price: price, Type: type, AffiliatedId: sellerExist.affiliatedId, ProductId: productExist.productId })
            } else if (type === 3) {
                await axios.post(apiUrl + '/Transaction', { DateTransaction: date, Price: price, Type: type, AffiliatedId: sellerExist.affiliatedId, ProductId: productExist.productId })
            } else {
                await axios.post(apiUrl + '/Transaction', { DateTransaction: date, Price: price, Type: type, CreatorId: sellerExist.creatorId, ProductId: productExist.productId })
            }
        } catch (error) {
            console.error(error);
        }
    }
}
