import React, { useEffect, useContext, useState, useRef } from "react";
//import { ListGroup, ListGroupItem, Card, CardImg, CardBody, Button, CardTitle, CardSubtitle, Container } from "reactstrap";
import { useParams, useHistory, Link } from "react-router-dom";
import { Button, CardImg, Form, Table, FormGroup, Label, Input } from "reactstrap";
import { ItemContext } from "../../providers/ItemProvider";


const RequestList = () => {


    const { requests, getCheckoutRequests, AddToCheckoutQueue, RemoveFromCheckoutQueue, ApproveCheckout, DeclineCheckoutRequest } = useContext(ItemContext);

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
                    <div key={request.id}>
                        {
                            !request.queueStartDate ?
                                <div className="items" >
                                    {/* < Link to={`item detai page TODO`}> */}
                                    {request.queueStartDate && "IN QUEUE"}
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
                                    <Button onClick={(e) => { e.preventDefault(); ApproveCheckout(request.checkoutId, request.itemId).then(getCheckoutRequests()) }}>
                                        APPROVE
                                    </Button>
                                    <Button onClick={(e) => { e.preventDefault(); DeclineCheckoutRequest(request.checkoutId).then(getCheckoutRequests()) }}>
                                        DECLINE
                                    </Button>
                                    {!request.queueStartDate ?
                                        <Button color="info" onClick={(e) => { e.preventDefault(); AddToCheckoutQueue(request.checkoutId).then(getCheckoutRequests()) }}>
                                            Add to Queue
                                    </Button>
                                        :
                                        <Button color="info" onClick={(e) => { e.preventDefault(); RemoveFromCheckoutQueue(request.checkoutId).then(getCheckoutRequests()) }}>
                                            Remove From Queue
                                    </Button>
                                    }
                                </div>
                                :
                                <div className="requestQueue" key={request.id}>
                                    {/* < Link to={`item detai page TODO`}> */}
                                    {request.queueStartDate && "IN QUEUE"}
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
                                    <Button onClick={(e) => { ApproveCheckout(request.checkoutId, request.itemId) }}>
                                        APPROVE
                                    </Button>
                                    <Button onClick={(e) => { DeclineCheckoutRequest(request.checkoutId) }}>
                                        DECLINE
                                    </Button>
                                    {!request.queueStartDate ?
                                        <Button color="info" onClick={(e) => { AddToCheckoutQueue(request.checkoutId) }}>
                                            Add to Queue
                        </Button>
                                        :
                                        <Button color="info" onClick={(e) => { RemoveFromCheckoutQueue(request.checkoutId) }}>
                                            Remove From Queue
                        </Button>
                                    }
                                </div>
                        }
                    </div>


                ))
                }
            </div>

        </>
    );
};

export default RequestList;
