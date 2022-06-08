import "./Main.css"
import React, { useState } from "react"
import { createTheme } from "react-data-table-component";
import { Outlet } from "react-router-dom";

import Header from "../header/Header"
import Footer from "../footer/Footer"

function Main() {
    const [url, setUrl] = useState("http://localhost:3000/auth")

    createTheme("custom", {
        text: {
            primary: '#58AA73',
            secondary: '#58AA73',
        },
        background: {
            default: '#263F39',
        },
        divider: {
            default: '#1d2b27',
        }
    },
        "dark"
    )

    return (
        <>
            <Header url={url} />
            <main className="main">
                <Outlet context={setUrl} />
            </main>
            <Footer />
        </>
    )
}

export default Main