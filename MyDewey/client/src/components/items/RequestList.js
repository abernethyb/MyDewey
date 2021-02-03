import React, { useEffect, useContext, useState, useRef } from "react";
//import { ListGroup, ListGroupItem, Card, CardImg, CardBody, Button, CardTitle, CardSubtitle, Container } from "reactstrap";
import { useParams, useHistory, Link } from "react-router-dom";
import { Button, CardImg, Form, Table, FormGroup, Label, Input } from "reactstrap";
import { ItemContext } from "../../providers/ItemProvider";


const RequestList = () => {


    const { requests, getCheckoutRequests } = useContext(ItemContext);

    const history = useHistory();


    useEffect(() => {

        getCheckoutRequests();
    }, []);

    if (!requests) {
        return null;
    }

    return (
        <>

            <div className="itemList">
                <div className="itemListTop">
                    <h2>Checkout Requests</h2>

                </div>

                {requests.map((request) => (

                    <div className="items" key={request.id}>
                        {/* < Link to={`item detai page TODO`}> */}
                        <p>Name: {request.itemName}</p>
                        <p>Borrower: {request.BorrowerUserName}</p>
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

export default RequestList;
