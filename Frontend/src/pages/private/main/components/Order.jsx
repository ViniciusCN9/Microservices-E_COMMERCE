import "./Order.css"
import React, { useEffect, useState } from "react";
import { useOutletContext } from "react-router-dom";
import DataTable from 'react-data-table-component';
import axios from "../../../../api/axios";

const ORDER_URL = "/Order"

function Order() {
    const setUrl = useOutletContext();
    const [total, setTotal] = useState("R$ 0,00")
    const [data, setData] = useState([])
    const config = {
        headers: { Authorization: `Bearer ${localStorage.getItem("token")}` }
    }

    useEffect(() => {
        setUrl(window.location.href)

        axios.get(ORDER_URL, config)
            .then(response => {
                if (response.data) {
                    let products = []

                    response.data.products.forEach(item => {
                        products.push({
                            productId: item.id,
                            product: item.description,
                            price: item.price.toLocaleString('pt-BR', { style: 'currency', currency: 'BRL', minimumFractionDigits: 2 })
                        })
                    })

                    if (products.length < 1) {
                        document.getElementById("check-out").setAttribute("disabled", "")
                    }

                    setData(products)
                    setTotal(response.data.totalValue.toLocaleString('pt-BR', { style: 'currency', currency: 'BRL', minimumFractionDigits: 2 }))
                } else {
                    document.getElementById("check-out").setAttribute("disabled", "")
                }
            })
    }, [total])

    const columns = [
        {
            name: "Product",
            selector: row => row.product,
            style: { color: "#fff" }
        },
        {
            name: "Price",
            selector: row => row.price,
            style: { color: "#fff" }
        },
        {
            cell: row => <button className="remove" onClick={() => removeProduct(row.productId)}>Remove</button>,
            button: true
        }
    ]

    function removeProduct(productId) {
        const body = { productId: productId }
        axios.post(`${ORDER_URL}/Remove`, JSON.stringify(body), config)
            .then(response => alert(response.data.response))
            .catch(error => error.response.data)

        document.location.reload()
    }

    function checkOut() {
        axios.post(`${ORDER_URL}/Finish`, {}, config)
            .then(response => alert(response.data.response))
            .catch(error => alert(error.response.data))
        document.location.reload()
    }

    return (
        <div className="order">
            <div className="table">
                <DataTable columns={columns} data={data} theme={"custom"} pagination />
            </div>
            <div className="options">
                <span>Total:</span>
                <p>{total}</p>
                <button id="check-out" onClick={() => checkOut()}>Check Out</button>
            </div>
        </div>
    )
}

export default Order