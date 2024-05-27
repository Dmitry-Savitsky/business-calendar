import React, { useState, useEffect } from 'react';
import { fetchOrders, createOrder, updateOrder, deleteOrder } from '../http/orderApi'; // Проверьте правильность пути
import { createOrderHasExecutor } from '../http/orderHasExecutorApi'; // Проверьте правильность пути
import { fetchExecutors} from '../http/executorApi'; // Проверьте правильность пути
import { Button, Container, Row, Col, Table, Modal, Form } from 'react-bootstrap';

const OrdersPage = () => {
    const [orders, setOrders] = useState([]);
    const [executors, setExecutors] = useState([]);
    const [showModal, setShowModal] = useState(false);
    const [showExecutorModal, setShowExecutorModal] = useState(false);
    const [selectedOrder, setSelectedOrder] = useState(null);
    const [selectedExecutor, setSelectedExecutor] = useState(null);
    const [orderComment, setOrderComment] = useState('');
    const [orderStart, setOrderStart] = useState('');
    const [orderEnd, setOrderEnd] = useState('');
    const [idClient, setIdClient] = useState('');
    const [idService, setIdService] = useState('');
    const [idClientAddress, setIdClientAddress] = useState('');

    useEffect(() => {
        loadOrders();
        loadExecutors();
    }, []);

    const loadOrders = async () => {
        try {
            const data = await fetchOrders();
            setOrders(data.$values || []);
        } catch (error) {
            console.error(error);
        }
    };

    const loadExecutors = async () => {
        try {
            const data = await fetchExecutors();
            setExecutors(data.$values || []);
        } catch (error) {
            console.error(error);
        }
    };

    const handleUpdateOrder = async (idOrder, field) => {
        try {
            const order = orders.find(order => order.idOrder === idOrder);
            if (!order) return;

            const updatedOrder = { ...order, [field]: true };
            await updateOrder(idOrder, updatedOrder);
            loadOrders();
        } catch (error) {
            console.error(error);
        }
    };

    const handleDeleteOrder = async (idOrder) => {
        try {
            await deleteOrder(idOrder);
            loadOrders();
        } catch (error) {
            console.error(error);
        }
    };

    const handleCreateOrder = async () => {
        try {
            const newOrder = {
                orderComment,
                orderStart,
                orderEnd,
                idClient,
                idService,
                idClientAddress
            };
            await createOrder(newOrder);
            loadOrders();
            setShowModal(false);
            setOrderComment('');
            setOrderStart('');
            setOrderEnd('');
            setIdClient('');
            setIdService('');
            setIdClientAddress('');
        } catch (error) {
            console.error(error);
        }
    };

    const handleAssignExecutor = async () => {
        try {
            if (!selectedOrder || !selectedExecutor) return;

            const orderHasExecutorData = {
                idOrder: selectedOrder.idOrder,
                idExecutor: selectedExecutor.idExecutor
            };

            await createOrderHasExecutor(orderHasExecutorData);
            setShowExecutorModal(false);
            setSelectedOrder(null);
            setSelectedExecutor(null);
        } catch (error) {
            console.error(error);
        }
    };

    return (
        <Container>
            <Row className="my-4">
                <Col>
                    <h1>Orders</h1>
                </Col>
            </Row>
            <Row>
                <Col>
                    <Table striped bordered hover>
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>Comment</th>
                                <th>Start</th>
                                <th>End</th>
                                <th>Client Name</th>
                                <th>Client Phone</th>
                                <th>Service Name</th>
                                <th>Client Address</th>
                                <th>Confirmed</th>
                                <th>Completed</th>
                                <th>Actions</th>
                            </tr>
                        </thead>
                        <tbody>
                            {orders.map((order, index) => (
                                <tr key={order.idOrder}>
                                    <td>{index + 1}</td>
                                    <td>{order.orderComment}</td>
                                    <td>{new Date(order.orderStart).toLocaleString()}</td>
                                    <td>{order.orderEnd ? new Date(order.orderEnd).toLocaleString() : 'N/A'}</td>
                                    <td>{order.client?.clientName}</td>
                                    <td>{order.client?.clientPhone}</td>
                                    <td>{order.service?.serviceName}</td>
                                    <td>{order.clientAddress?.address}</td>
                                    <td>
                                        {order.confirmed ? '✅' : (
                                            <Button
                                                variant="success"
                                                onClick={() => handleUpdateOrder(order.idOrder, 'confirmed')}
                                            >
                                                ✅
                                            </Button>
                                        )}
                                    </td>
                                    <td>
                                        {order.completed ? '✅' : (
                                            <Button
                                                variant="success"
                                                onClick={() => handleUpdateOrder(order.idOrder, 'completed')}
                                            >
                                                ✅
                                            </Button>
                                        )}
                                    </td>
                                    <td>
                                        <Button
                                            variant="danger"
                                            onClick={() => handleDeleteOrder(order.idOrder)}
                                        >
                                            ☓
                                        </Button>
                                        <Button
                                            variant="primary"
                                            onClick={() => {
                                                setSelectedOrder(order);
                                                setShowExecutorModal(true);
                                            }}
                                        >
                                            Assign executor
                                        </Button>
                                    </td>
                                </tr>
                            ))}
                        </tbody>
                    </Table>
                </Col>
            </Row>
            <Row className="my-4">
                <Col>
                    <Button variant="primary" onClick={() => setShowModal(true)}>+</Button>
                </Col>
            </Row>

            {/* Модальное окно для создания заказа */}
            <Modal show={showModal} onHide={() => setShowModal(false)}>
                <Modal.Header closeButton>
                    <Modal.Title>Create Order</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Form>
                        <Form.Group controlId="orderComment">
                            <Form.Label>Order Comment</Form.Label>
                            <Form.Control
                                type="text"
                                placeholder="Enter order comment"
                                value={orderComment}
                                onChange={(e) => setOrderComment(e.target.value)}
                            />
                        </Form.Group>
                        <Form.Group controlId="orderStart">
                            <Form.Label>Order Start</Form.Label>
                            <Form.Control
                                type="datetime-local"
                                value={orderStart}
                                onChange={(e) => setOrderStart(e.target.value)}
                            />
                        </Form.Group>
                        <Form.Group controlId="orderEnd">
                            <Form.Label>Order End</Form.Label>
                            <Form.Control
                                type="datetime-local"
                                value={orderEnd}
                                onChange={(e) => setOrderEnd(e.target.value)}
                            />
                        </Form.Group>
                        <Form.Group controlId="idClient">
                            <Form.Label>Client ID</Form.Label>
                            <Form.Control
                                type="text"
                                placeholder="Enter client ID"
                                value={idClient}
                                onChange={(e) => setIdClient(e.target.value)}
                            />
                        </Form.Group>
                        <Form.Group controlId="idService">
                            <Form.Label>Service ID</Form.Label>
                            <Form.Control
                                type="text"
                                placeholder="Enter service ID"
                                value={idService}
                                onChange={(e) => setIdService(e.target.value)}
                            />
                        </Form.Group>
                        <Form.Group controlId="idClientAddress">
                            <Form.Label>Client Address ID</Form.Label>
                            <Form.Control
                                type="text"
                                placeholder="Enter client address ID"
                                value={idClientAddress}
                                onChange={(e) => setIdClientAddress(e.target.value)}
                            />
                        </Form.Group>
                    </Form>
                </Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={() => setShowModal(false)}>Close</Button>
                    <Button variant="primary" onClick={handleCreateOrder}>Create Order</Button>
                </Modal.Footer>
            </Modal>

            {/* Модальное окно для назначения исполнителя */}
            <Modal show={showExecutorModal} onHide={() => setShowExecutorModal(false)}>
                <Modal.Header closeButton>
                    <Modal.Title>Assign Executor</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Form>
                        <Form.Group controlId="selectExecutor">
                            <Form.Label>Select Executor</Form.Label>
                            <Form.Control
                                as="select"
                                value={selectedExecutor?.idExecutor || ''}
                                onChange={(e) => setSelectedExecutor(executors.find(executor => executor.idExecutor === parseInt(e.target.value)))}
                            >
                                <option value="">Select Executor</option>
                                {executors.map((executor) => (
                                    <option key={executor.idExecutor} value={executor.idExecutor}>
                                        {executor.executorName}
                                    </option>
                                ))}
                            </Form.Control>
                        </Form.Group>
                    </Form>
                </Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={() => setShowExecutorModal(false)}>Close</Button>
                    <Button variant="primary" onClick={handleAssignExecutor}>Approve</Button>
                </Modal.Footer>
            </Modal>
        </Container>
    );
};


export default OrdersPage;