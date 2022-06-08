import "./Catalog.css"
import React, { useState, useEffect } from "react";
import { useOutletContext } from "react-router-dom";
import DataTable from 'react-data-table-component';
import axios from "../../../../api/axios";

const CATALOG_URL = "/Catalog"
const ORDER_URL = "/Order"

function Catalog() {
    const setUrl = useOutletContext();
    const [data, setData] = useState([])

    useEffect(() => {
        setUrl(window.location.href)

        axios.get(CATALOG_URL)
            .then(response => {
                const items = response.data
                items.forEach(item => {
                    item.price = item.price.toLocaleString('pt-BR', { style: 'currency', currency: 'BRL', minimumFractionDigits: 2 })
                    item.category = fillCategory(item.category)
                })

                setData(items)
            })
            .catch(error => console.log(error.response.data))
    }, [])

    const columns = [
        {
            name: "Id",
            selector: row => row.id,
            style: { color: "#fff" }
        },
        {
            name: "Description",
            selector: row => row.description,
            style: { color: "#fff" }
        },
        {
            name: "Category",
            selector: row => row.category,
            style: { color: "#fff" }
        },
        {
            name: "Price",
            selector: row => row.price,
            style: { color: "#fff" }
        }
    ]

    function fillCategory(categoryNumber) {
        switch (categoryNumber) {
            case 1:
                return "Notebook"
            case 2:
                return "Desktop"
            case 3:
                return "Mobile"
            default:
                return "Uncategorized"
        }
    }

    async function addOnOrder(productId) {
        const config = {
            headers: { Authorization: `Bearer ${localStorage.getItem("token")}` }
        }

        let orderId = localStorage.getItem("orderId")
        if (!orderId) {
            await axios.post(ORDER_URL, {}, config)
                .then(response => {
                    localStorage.setItem("orderId", response.data.orderId)
                    orderId = localStorage.getItem("orderId")
                })
        }

        const body = { orderId: parseInt(orderId), productId: productId }
        axios.post(`${ORDER_URL}/Add`, JSON.stringify(body), config)
            .then(response => alert(response.data.response))
            .catch(error => error.response.data)
    }


    return (
        <div className="catalog">
            <div className="table">
                <DataTable columns={columns} data={data} theme={"custom"} highlightOnHover pointerOnHover onRowClicked={(row) => addOnOrder(row.id)} pagination />
            </div>
        </div>
    )
}

export default Catalog