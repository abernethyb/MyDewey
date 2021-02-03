import React, { useEffect, useContext, useState, useRef } from "react";
//import { ListGroup, ListGroupItem, Card, CardImg, CardBody, Button, CardTitle, CardSubtitle, Container } from "reactstrap";
import { useParams, useHistory, Link } from "react-router-dom";
import { Button, CardImg, Form, Table, FormGroup, Label, Input } from "reactstrap";
import { ItemContext } from "../../providers/ItemProvider";


const RequestList = () => {


    const { requests, getCheckoutRequests, AddToCheckoutQueue } = useContext(ItemContext);

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
                        {request.queueStartDate ? "IN QUEUE" : "Not in queue"}
                        <p>Name: {request.itemName}</p>
                        <p>Borrower: {request.borrowerUserName}</p>
                        <p>{`At ${new Date(request.requestDate).getHours() > 12 ? new Date(request.requestDate).getHours() - 12 : new Date(request.requestDate).getHours()}:${new Date(request.requestDate).getHours() > 12 ? new Date(request.requestDate).getMinutes() + " PM" : new Date(request.requestDate).getMinutes() + " AM"} on ${new Date(request.requestDate).getMonth() + 1}/${new Date(request.requestDate).getDate()}/${new Date(request.requestDate).getFullYear()}`}</p>

                        {/* <Image fluid rounded src={sample.image} alt={sample.name}></Image> */}

                        {/* <ReactImageFallback
                                width="100%"
                                src={`/api/image/${item.image}`}
                                fallbackImage={item.image}
                                alt={sample.name} /> */}
                        {/* </Link> */}
                        <Button>
                            APPROVE
                        </Button>
                        <Button>
                            DECLINE
                        </Button>
                        <Button color="info" onClick={(e) => { AddToCheckoutQueue(request.checkoutId) }}>
                            Add to Queue
                        </Button>
                    </div>


                ))
                }
            </div>

        </>
    );
};

export default RequestList;
