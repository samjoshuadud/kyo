-- Add Unit Price to Delivery Items
ALTER TABLE delivery_items
ADD COLUMN unit_price DECIMAL(10,2) NOT NULL,
ADD COLUMN batch_number VARCHAR(50),
ADD COLUMN status ENUM('active', 'expired', 'disposed') DEFAULT 'active';

-- Enhance Inventory Table
ALTER TABLE inventory
ADD COLUMN minimum_stock INT DEFAULT 10,
ADD COLUMN maximum_stock INT DEFAULT 100,
ADD COLUMN last_delivery_date DATE,
ADD COLUMN last_stock_count DATE,
ADD COLUMN status ENUM('in_stock', 'low_stock', 'out_of_stock') DEFAULT 'in_stock';

-- Improve Deliveries Table
ALTER TABLE deliveries
ADD COLUMN status ENUM('pending', 'received', 'cancelled') DEFAULT 'pending',
ADD COLUMN notes TEXT,
ADD COLUMN received_by INT,
ADD FOREIGN KEY (received_by) REFERENCES users(user_id);

-- Add Batch Tracking to Products
ALTER TABLE products
ADD COLUMN reorder_point INT DEFAULT 10,
ADD COLUMN unit_of_measure VARCHAR(20) DEFAULT 'piece',
ADD COLUMN is_active BOOLEAN DEFAULT TRUE,
ADD COLUMN supplier_id INT,
ADD FOREIGN KEY (supplier_id) REFERENCES suppliers(supplier_id);

-- Enhance Suppliers Table
ALTER TABLE suppliers
ADD COLUMN contact_person VARCHAR(100),
ADD COLUMN payment_terms VARCHAR(50),
ADD COLUMN tax_id VARCHAR(50),
ADD COLUMN credit_limit DECIMAL(10,2),
ADD COLUMN status ENUM('active', 'inactive') DEFAULT 'active',
ADD COLUMN lead_time INT COMMENT 'Average delivery time in days',
ADD COLUMN rating INT CHECK (rating >= 1 AND rating <= 5);

-- Create Product Price History Table
CREATE TABLE product_price_history (
    history_id INT PRIMARY KEY AUTO_INCREMENT,
    product_id INT,
    old_cost_price DECIMAL(10,2),
    new_cost_price DECIMAL(10,2),
    old_selling_price DECIMAL(10,2),
    new_selling_price DECIMAL(10,2),
    change_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    changed_by INT,
    FOREIGN KEY (product_id) REFERENCES products(product_id),
    FOREIGN KEY (changed_by) REFERENCES users(user_id)
);

-- Create Stock Movement Table
CREATE TABLE stock_movements (
    movement_id INT PRIMARY KEY AUTO_INCREMENT,
    product_id INT,
    movement_type ENUM('delivery', 'sale', 'adjustment', 'disposal'),
    quantity INT,
    reference_id VARCHAR(50),
    movement_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    performed_by INT,
    notes TEXT,
    FOREIGN KEY (product_id) REFERENCES products(product_id),
    FOREIGN KEY (performed_by) REFERENCES users(user_id)
); 