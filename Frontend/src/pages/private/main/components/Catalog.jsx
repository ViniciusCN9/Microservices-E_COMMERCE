import "./Catalog.css"
import React, { useState, useEffect } from "react";
import { useOutletContext } from "react-router-dom";
import DataTable from 'react-data-table-component';
import axios from "../../../../api/axios";
import useAuth from "../../../../hooks/useAuth";

const CATALOG_URL = "/Catalog"
const ORDER_URL = "/Order"

function Catalog() {
    const role = localStorage.getItem("role")

    const config = {
        headers: { Authorization: `Bearer ${localStorage.getItem("token")}` }
    }

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
        axios.get(ORDER_URL, config)
            .then(response => {
                if (response.data) {
                    const body = { productId: productId }
                    axios.post(`${ORDER_URL}/Add`, JSON.stringify(body), config)
                        .then(response => alert(response.data.response))
                        .catch(error => console.log(error.response.data))
                } else {
                    axios.post(ORDER_URL, {}, config)
                        .then(() => addOnOrder(productId))
                        .catch(error => console.log(error.response.data))
                }
            }).catch(error => console.log(error.response.data))
    }

    const [description, setDescription] = useState("")
    const [price, setPrice] = useState("")
    const [category, setCategory] = useState("")

    function handleSubmit(e) {
        e.preventDefault()

        const body = { description: description.toUpperCase(), price: parseFloat(price), category: parseInt(category) }
        axios.post(`${CATALOG_URL}/Create`, JSON.stringify(body), config)
            .then(response => console.log(response.data))
            .catch(error => console.log(error.response.data))

        document.location.reload()
    }

    function cancelAdd(e) {
        e.preventDefault()

        setDescription("")
        setPrice("")
        setCategory("")
    }

    if (role == 0) {
        return (
            < div className="catalog-admin" >
                <form className="form-catalog" onSubmit={handleSubmit}>
                    <div className="field-catalog">
                        <div className="field-description">
                            <label htmlFor="description">Description</label>
                            <input
                                type="description"
                                name="description"
                                id="description"
                                value={description}
                                onChange={e => setDescription(e.target.value)}
                                required
                            />
                        </div>
                        <div className="field-price">
                            <label htmlFor="price">Price</label>
                            <input
                                type="price"
                                name="price"
                                id="price"
                                value={price}
                                onChange={e => setPrice(e.target.value)}
                                required
                            />
                        </div>
                        <select value={category} onChange={e => setCategory(e.target.value)} name="category">
                            <option disabled value="">Category</option>
                            <option value="1">Notebook</option>
                            <option value="2">Desktop</option>
                            <option value="3">Mobile</option>
                        </select>
                    </div>
                    <div className="actions-catalog">
                        <button type="submit">Add</button>
                        <button onClick={e => cancelAdd(e)}>Cancel</button>
                    </div>
                </form>
                <div className="table-admin">
                    <DataTable columns={columns} data={data} theme={"custom"} pagination />
                </div>
            </div >
        )
    }

    return (
        < div className="catalog" >
            <div className="table">
                <DataTable columns={columns} data={data} theme={"custom"} highlightOnHover pointerOnHover onRowClicked={(row) => addOnOrder(row.id)} pagination />
            </div>
        </div >
    )
}

export default Catalog