import "./Home.css"
import 'animate.css';
import React, { useEffect } from "react";
import { useOutletContext } from "react-router-dom";

function Home() {
    const setUrl = useOutletContext();

    useEffect(() => {
        setUrl(window.location.href)
    }, [])

    return (
        <div className="home">
            <p className="animate__animated animate__fadeIn animate__delay-1s">Lorem ipsum dolor sit amet consectetur adipisicing elit. Dolore, temporibus? Sapiente eius veritatis consequuntur hic, quo consequatur doloremque, sit suscipit eos ipsa dicta temporibus, tempore dolores eveniet deleniti labore illum?</p>
            <p className="animate__animated animate__fadeIn animate__delay-2s">Lorem ipsum dolor sit amet consectetur, adipisicing elit. Libero nesciunt cum repellendus aliquam veniam. Veritatis neque dignissimos consectetur facere perferendis similique, necessitatibus asperiores magni? Tenetur dolorem eius repellendus suscipit fuga.</p>
            <p className="animate__animated animate__fadeIn animate__delay-5s">Lorem ipsum dolor sit amet consectetur adipisicing elit. Est, eum voluptates. Neque tenetur voluptatibus cupiditate, eius quae repudiandae explicabo dolore illo atque, maiores nihil impedit quis, animi doloribus praesentium dolorem.</p>
            <p className="animate__animated animate__fadeIn animate__delay-3s">Lorem ipsum dolor sit amet consectetur adipisicing elit. Deleniti, ea velit. Consectetur laborum mollitia dicta cum. Ullam placeat aperiam expedita repellat. Modi porro asperiores sit eligendi excepturi dolorum, magnam saepe!</p>
            <p className="animate__animated animate__fadeIn animate__delay-4s">Lorem ipsum dolor sit amet consectetur adipisicing elit. Ullam rerum delectus quia voluptate dicta animi, est reiciendis nobis odit tempora inventore similique perferendis. Vero optio perferendis eum laboriosam, exercitationem porro!</p>
        </div>
    )
}

export default Home