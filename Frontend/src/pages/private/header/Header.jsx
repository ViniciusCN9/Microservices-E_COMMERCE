import "./Header.css"
import React from "react"

import Logo from "./components/Logo"
import Nav from "./components/Nav"
import Option from "./components/Option"

function Header(props) {
    return (
        <header className="header">
            <Logo />
            <Nav url={props.url} />
            <Option />
        </header>
    )
}

export default Header