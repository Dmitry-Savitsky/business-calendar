import React, { useState, useEffect } from 'react';
import { fetchExecutors, createExecutor, deleteExecutor } from '../http/executorApi'; // Предполагается, что api находится в файле executorApi.js

const ExecutorsPage = () => {
    const [executors, setExecutors] = useState([]);
    const [executorName, setExecutorName] = useState('');
    const [executorPhone, setExecutorPhone] = useState('');

    useEffect(() => {
        loadExecutors();
    }, []);

    const loadExecutors = async () => {
        try {
            const data = await fetchExecutors();
            setExecutors(data);
        } catch (error) {
            console.error(error);
        }
    };

    const handleCreateExecutor = async () => {
        try {
            await createExecutor({ executorName, executorPhone });
            loadExecutors();
            setExecutorName('');
            setExecutorPhone('');
        } catch (error) {
            console.error(error);
        }
    };

    const handleDeleteExecutor = async (idExecutor) => {
        try {
            await deleteExecutor(idExecutor);
            loadExecutors();
        } catch (error) {
            console.error(error);
        }
    };

    return (
        <div>
            <h1>Executors</h1>
            <input
                type="text"
                placeholder="Executor Name"
                value={executorName}
                onChange={(e) => setExecutorName(e.target.value)}
            />
            <input
                type="text"
                placeholder="Executor Phone"
                value={executorPhone}
                onChange={(e) => setExecutorPhone(e.target.value)}
            />
            <button onClick={handleCreateExecutor}>Add Executor</button>
            <ul>
                {executors.map(executor => (
                    <li key={executor.idExecutor}>
                        {executor.executorName} - {executor.executorPhone}
                        <button onClick={() => handleDeleteExecutor(executor.idExecutor)}>Delete</button>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default ExecutorsPage;