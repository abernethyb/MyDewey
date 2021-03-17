import React, { useEffect, useContext, useState, useRef } from "react";
//import { ListGroup, ListGroupItem, Card, CardImg, CardBody, Button, CardTitle, CardSubtitle, Container } from "reactstrap";
import { useParams, useHistory, Link } from "react-router-dom";
import { Button, CardImg, Form, Table, FormGroup, Label, Input } from "reactstrap";
import { ItemContext } from "../../providers/ItemProvider";
import "./item.css"


const ItemList = () => {


    const { items, getNonUserItems, RequestCheckout } = useContext(ItemContext);

    const history = useHistory();


    useEffect(() => {

        getNonUserItems();
    }, []);

    if (!items) {
        return null;
    }


    return (
        <>

            <div className="itemList">
                <div className="itemListTop">
                    <h2>Public Library</h2>
                </div>

                {items.map((item) => (

                    <div className="items" key={item.id}>
                        {/* < Link to={`item detai page TODO`}> */}
                        <p>Name: {item.name}</p>
                        <p>Owner: {item.ownerUserName}</p>
                        <p>Category: {item.categoryName}</p>
                        <p>Location: {item.ownerPostalCode}</p>
                        <Button color="info" onClick={(e) => { e.preventDefault(); RequestCheckout(item.id).then(getNonUserItems()) }}>
                            Request Checkout
                        </Button>
                        {/* <Button color="info" onClick={handleCheckoutRequestClick(item)}>
                            Requesttttt Checkout
                        </Button> */}
                        {/* <Image fluid rounded src={sample.image} alt={sample.name}></Image> */}

                        {/* <ReactImageFallback
                                width="100%"
                                src={`/api/image/${item.image}`}
                                fallbackImage={item.image}
                                alt={sample.name} /> */}
                        {/* </Link> */}

                    </div>


                ))
                }
            </div>

        </>
    );
};

export default ItemList;
