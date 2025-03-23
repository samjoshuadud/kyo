-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Mar 22, 2025 at 01:55 PM
-- Server version: 8.4.3
-- PHP Version: 8.3.16

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `smgsisbstp`
--

-- --------------------------------------------------------

--
-- Table structure for table `audittrail`
--

CREATE TABLE `audittrail` (
  `AuditID` int NOT NULL,
  `Role` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `FullName` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `Action` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `Form` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `Date` datetime DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `audittrail`
--

INSERT INTO `audittrail` (`AuditID`, `Role`, `FullName`, `Action`, `Form`, `Date`) VALUES
(3, 'Staff', 'Ryaxe Zoldyck', 'User added successfully! Assigned User ID: 36', 'UserMain', '2025-03-07 11:12:39'),
(4, 'Cashier', 'alex comadre', 'User added successfully! Assigned User ID: 37', 'UserMain', '2025-03-07 20:06:34'),
(7, 'Staff', 'oreo visperas', 'User added successfully! Assigned User ID: 39', 'UserMain', '2025-03-07 21:01:24'),
(8, '', 'asi visperas', 'User deleted successfully! User ID: 28', 'UserMain', '2025-03-07 21:03:27'),
(9, 'Staff', 'alex comadre', 'User deleted successfully! User ID: 37', 'UserMain', '2025-03-07 21:03:50'),
(10, 'Staff', 'Ryaxe Zoldyck', 'User deleted successfully! User ID: 36', 'UserMain', '2025-03-08 02:15:30'),
(11, 'Staff', 'oreo visperas', 'User deleted successfully! User ID: 39', 'UserMain', '2025-03-08 02:17:16'),
(12, 'Staff', 'kenneth visperas', 'User deleted successfully! User ID: 32', 'UserMain', '2025-03-08 02:17:35'),
(13, 'Cashier', 'keny 23', 'User added successfully! Assigned User ID: 40', 'UserMain', '2025-03-08 02:18:16'),
(14, '', 'keny qwe', 'User deleted successfully! User ID: 33', 'UserMain', '2025-03-08 02:18:31'),
(15, 'Cashier', 'keny vbn', 'User added successfully! Assigned User ID: 41', 'UserMain', '2025-03-08 02:19:47'),
(16, 'Cashier', 'keny vbn', 'User deleted successfully! User ID: 41', 'UserMain', '2025-03-08 02:19:52'),
(17, 'Cashier', 'keny visperas', 'User added successfully! Assigned User ID: 43', 'UserMain', '2025-03-11 05:27:23'),
(18, 'Cashier', 'keny 23', 'User deleted successfully! User ID: 40', 'UserMain', '2025-03-11 05:27:27'),
(19, '', 'keny visperas', 'User deleted successfully! User ID: 43', 'UserMain', '2025-03-11 06:34:58'),
(20, '', 'keny visperas', 'User deleted successfully! User ID: 43', 'UserMain', '2025-03-11 06:35:05'),
(21, 'Cashier', 'pong yas', 'User added successfully! Assigned User ID: 44', 'UserMain', '2025-03-11 06:36:40'),
(22, 'Cashier', 'pong yas', 'User deleted successfully! User ID: 44', 'UserMain', '2025-03-11 06:36:44'),
(23, 'Staff', 'marlo visperas', 'User added successfully! Assigned User ID: 45', 'UserMain', '2025-03-11 06:39:39'),
(24, 'Staff', 'marlo visperas', 'User updated successfully! User ID: 45', 'UserMain', '2025-03-11 06:40:10'),
(25, 'Staff', 'marlo visperas', 'User deleted successfully! User ID: 45', 'UserMain', '2025-03-11 06:41:22'),
(26, 'Cashier', 'maricel visperas', 'User added successfully! Assigned User ID: 46', 'UserMain', '2025-03-11 06:42:28'),
(27, 'Cashier', 'maricel visperas', 'User deleted successfully! User ID: 46', 'UserMain', '2025-03-11 06:45:25'),
(28, 'Cashier', 'cvbnm  fghjk', 'User added successfully! Assigned User ID: 47', 'UserMain', '2025-03-11 06:46:28'),
(30, 'Cashier', 'pong fghjk', 'User added successfully! Assigned User ID: 48', 'UserMain', '2025-03-11 12:35:15'),
(31, 'Staff', 'vannessa Visperas', 'User added successfully! Assigned User ID: 49', 'UserMain', '2025-03-11 12:37:15'),
(32, 'Staff', 'vannessa Visperas', 'User updated successfully! User ID: 49', 'UserMain', '2025-03-11 12:37:26'),
(33, 'Staff', 'vannessa Visperas', 'User deleted successfully! User ID: 49', 'UserMain', '2025-03-11 14:00:11'),
(34, 'Cashier', 'Ricky bote', 'User added successfully! Assigned User ID: 50', 'UserMain', '2025-03-11 14:09:00'),
(35, '', 'Ricky bote', 'User deleted successfully! User ID: 50', 'UserMain', '2025-03-11 14:09:15'),
(36, '', 'pong fghjk', 'User deleted successfully! User ID: 48', 'UserMain', '2025-03-11 14:27:11'),
(37, 'Cashier', 'marlo visperas', 'User added successfully! Assigned User ID: 51', 'UserMain', '2025-03-11 14:28:48'),
(38, 'Cashier', 'marlo visperas', 'User updated successfully! User ID: 51', 'UserMain', '2025-03-11 14:43:41'),
(39, 'Cashier', 'oreo boy J visperas', 'User added successfully! Assigned User ID: 52', 'UserMain', '2025-03-11 14:47:44'),
(40, 'Cashier', 'yong J visperas', 'User added successfully! Assigned User ID: 53', 'UserMain', '2025-03-11 18:31:32'),
(41, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-19 15:24:26'),
(42, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-19 19:19:54'),
(43, 'Cashier', 'cashierrrrr c cashierrrrr', 'User added successfully! Assigned User ID: 54', 'UserMain', '2025-03-19 19:21:55'),
(44, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-19 19:21:58'),
(45, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-19 19:23:12'),
(46, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-19 19:24:59'),
(47, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-19 19:37:55'),
(48, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-19 20:02:44'),
(49, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-19 20:37:13'),
(50, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-19 20:38:59'),
(51, 'Cashier', 'joshua a arm', 'User added successfully! Assigned User ID: 55', 'UserMain', '2025-03-19 21:34:34'),
(52, 'Staff', 'cj ja jc', 'User added successfully! Assigned User ID: 56', 'UserMain', '2025-03-19 21:35:14'),
(53, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-19 21:35:25'),
(54, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-19 23:53:43'),
(55, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-20 00:00:45'),
(56, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-20 00:44:17'),
(57, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-20 00:45:14'),
(58, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-20 00:51:46'),
(59, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-20 00:51:57'),
(60, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-20 01:09:24'),
(61, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-20 01:10:00'),
(62, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-22 14:04:21'),
(63, 'Admin', 'Administrator', 'Added a new category: Junk Foods', 'CategoryMain', '2025-03-22 14:07:16'),
(64, 'Admin', 'Administrator', 'Updated category: Name changed from \'Junk Foods\' to \'Junk Foodss\'. Description changed from \'testa\' to \'testss\'.', 'CategoryMain', '2025-03-22 14:07:24'),
(65, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-22 14:13:03');

-- --------------------------------------------------------

--
-- Table structure for table `categories`
--

CREATE TABLE `categories` (
  `category_id` int NOT NULL,
  `category_name` varchar(50) COLLATE utf8mb4_general_ci NOT NULL,
  `description` text COLLATE utf8mb4_general_ci,
  `created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `categories`
--

INSERT INTO `categories` (`category_id`, `category_name`, `description`, `created_at`, `updated_at`) VALUES
(8, 'Junk Food', 'test', '2024-12-07 00:26:43', '2024-12-07 00:26:43'),
(9, 'Drinks', 'test', '2024-12-07 00:26:52', '2024-12-07 00:26:52'),
(10, 'Canned Goods', 'test', '2024-12-07 00:27:03', '2024-12-07 00:27:03'),
(11, 'Alcoholol', 'lol', '2024-12-07 00:27:17', '2024-12-19 06:27:04'),
(13, 'test', 'mnb', '2025-03-07 13:37:46', '2025-03-07 13:37:46'),
(14, 'Junk Foodss', 'testss', '2025-03-22 06:07:15', '2025-03-22 06:07:23');

-- --------------------------------------------------------

--
-- Table structure for table `deliveries`
--

CREATE TABLE `deliveries` (
  `delivery_id` int NOT NULL,
  `supplier_id` int NOT NULL,
  `transaction_number` varchar(50) COLLATE utf8mb4_general_ci NOT NULL,
  `delivery_date` date NOT NULL,
  `received_date` date DEFAULT NULL,
  `created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `deliveries`
--

INSERT INTO `deliveries` (`delivery_id`, `supplier_id`, `transaction_number`, `delivery_date`, `received_date`, `created_at`, `updated_at`) VALUES
(237, 10, 'TRX-20241207083625', '2024-12-11', NULL, '2024-12-07 00:36:45', '2024-12-07 00:36:45'),
(238, 9, 'TRX-20241207084138', '2024-12-07', NULL, '2024-12-07 00:41:42', '2024-12-07 00:41:42'),
(239, 9, 'TRX-20241207084910', '2024-12-07', NULL, '2024-12-07 00:49:15', '2024-12-07 00:49:15'),
(240, 9, 'TRX-20241207085438', '2024-12-07', NULL, '2024-12-07 00:54:44', '2024-12-07 00:54:44'),
(241, 9, 'TRX-20241220134614', '2024-12-21', NULL, '2024-12-20 05:46:21', '2024-12-20 05:46:21'),
(242, 9, 'TRX-20241220135948', '2024-12-21', NULL, '2024-12-20 06:00:05', '2024-12-20 06:00:05'),
(243, 9, 'TRX-20241220141555', '2024-12-21', NULL, '2024-12-20 06:16:05', '2024-12-20 06:16:05'),
(244, 9, 'TRX-20241220141703', '2024-12-21', NULL, '2024-12-20 06:17:10', '2024-12-20 06:17:10'),
(245, 9, 'TRX-20241220143302', '2024-12-21', NULL, '2024-12-20 06:33:06', '2024-12-20 06:33:06'),
(246, 9, 'TRX-20241220175859', '2024-12-21', NULL, '2024-12-20 09:59:07', '2024-12-20 09:59:07'),
(253, 9, 'TRX-20250309101855', '2025-03-10', NULL, '2025-03-09 02:19:11', '2025-03-09 02:19:11'),
(254, 9, 'TRX-20250309133640', '2025-03-10', NULL, '2025-03-09 05:36:51', '2025-03-09 05:36:51'),
(255, 9, 'TRX-20250309134629', '2025-03-06', NULL, '2025-03-09 05:46:49', '2025-03-09 05:46:49'),
(256, 9, 'TRX-20250309134723', '2025-03-07', NULL, '2025-03-09 05:47:30', '2025-03-09 05:47:30'),
(258, 18, 'TRX-20250309155225', '2025-03-09', NULL, '2025-03-09 07:52:30', '2025-03-09 07:52:30'),
(259, 18, 'TRX-20250309155415', '2025-03-09', NULL, '2025-03-09 07:54:20', '2025-03-09 07:54:20'),
(260, 18, 'TRX-20250309155640', '2025-03-09', NULL, '2025-03-09 07:56:46', '2025-03-09 07:56:46'),
(261, 9, 'TRX-20250309155707', '2025-03-09', NULL, '2025-03-09 07:57:10', '2025-03-09 07:57:10'),
(262, 9, 'TRX-20250309155905', '2025-03-05', NULL, '2025-03-09 07:59:27', '2025-03-09 07:59:27'),
(263, 9, 'TRX-20250309160311', '2025-03-09', NULL, '2025-03-09 08:03:15', '2025-03-09 08:03:15'),
(264, 9, 'TRX-20250309161232', '2025-03-09', NULL, '2025-03-09 08:12:34', '2025-03-09 08:12:34'),
(265, 9, 'TRX-20250309161735', '2025-03-09', NULL, '2025-03-09 08:17:37', '2025-03-09 08:17:37'),
(266, 9, 'TRX-20250309162840', '2025-03-09', NULL, '2025-03-09 08:28:41', '2025-03-09 08:28:41'),
(267, 9, 'TRX-20250309163010', '2025-03-09', NULL, '2025-03-09 08:30:11', '2025-03-09 08:30:11'),
(268, 18, 'TRX-20250309163126', '2025-03-09', NULL, '2025-03-09 08:31:36', '2025-03-09 08:31:36'),
(269, 9, 'TRX-20250309163328', '2025-03-09', NULL, '2025-03-09 08:33:30', '2025-03-09 08:33:30'),
(270, 9, 'TRX-20250309163601', '2025-03-08', NULL, '2025-03-09 08:36:14', '2025-03-09 08:36:14'),
(271, 9, 'TRX-20250309164029', '2025-03-09', NULL, '2025-03-09 08:40:32', '2025-03-09 08:40:32'),
(272, 9, 'TRX-20250309164328', '2025-03-09', NULL, '2025-03-09 08:43:29', '2025-03-09 08:43:29'),
(273, 18, 'TRX-20250309164751', '2025-03-09', NULL, '2025-03-09 08:47:55', '2025-03-09 08:47:55'),
(274, 9, 'TRX-20250309165115', '2025-03-09', NULL, '2025-03-09 08:51:16', '2025-03-09 08:51:16'),
(275, 9, 'TRX-20250309165346', '2025-03-09', NULL, '2025-03-09 08:53:47', '2025-03-09 08:53:47'),
(276, 9, 'TRX-20250309165534', '2025-03-09', NULL, '2025-03-09 08:55:35', '2025-03-09 08:55:35'),
(277, 18, 'TRX-20250309165624', '2025-03-09', NULL, '2025-03-09 08:56:30', '2025-03-09 08:56:30'),
(278, 18, 'TRX-20250309165659', '2025-03-09', NULL, '2025-03-09 08:57:03', '2025-03-09 08:57:03'),
(279, 9, 'TRX-20250309170223', '2025-03-09', NULL, '2025-03-09 09:02:25', '2025-03-09 09:02:25'),
(280, 18, 'TRX-20250309170501', '2025-03-09', NULL, '2025-03-09 09:05:05', '2025-03-09 09:05:05'),
(281, 18, 'TRX-20250309170843', '2025-03-09', NULL, '2025-03-09 09:08:48', '2025-03-09 09:08:48'),
(282, 9, 'TRX-20250309170932', '2025-03-09', NULL, '2025-03-09 09:10:11', '2025-03-09 09:10:11'),
(283, 18, 'TRX-20250309171220', '2025-03-09', NULL, '2025-03-09 09:12:25', '2025-03-09 09:12:25'),
(284, 9, 'TRX-20250309172142', '2025-03-09', NULL, '2025-03-09 09:21:45', '2025-03-09 09:21:45'),
(285, 9, 'TRX-20250309172654', '2025-03-09', NULL, '2025-03-09 09:26:54', '2025-03-09 09:26:54'),
(286, 18, 'TRX-20250309172708', '2025-03-09', NULL, '2025-03-09 09:27:11', '2025-03-09 09:27:11'),
(287, 9, 'TRX-20250309173310', '2025-03-09', NULL, '2025-03-09 09:33:10', '2025-03-09 09:33:10'),
(288, 9, 'TRX-20250309173348', '2025-03-09', NULL, '2025-03-09 09:33:50', '2025-03-09 09:33:50'),
(289, 9, 'TRX-20250309173532', '2025-03-09', NULL, '2025-03-09 09:35:33', '2025-03-09 09:35:33'),
(290, 9, 'TRX-20250309173655', '2025-03-09', NULL, '2025-03-09 09:36:56', '2025-03-09 09:36:56'),
(291, 9, 'TRX-20250309173744', '2025-03-09', NULL, '2025-03-09 09:37:45', '2025-03-09 09:37:45'),
(292, 9, 'TRX-20250309173921', '2025-03-09', NULL, '2025-03-09 09:39:22', '2025-03-09 09:39:22'),
(293, 18, 'TRX-20250309173947', '2025-03-09', NULL, '2025-03-09 09:39:51', '2025-03-09 09:39:51'),
(294, 9, 'TRX-20250309174201', '2025-03-09', NULL, '2025-03-09 09:42:03', '2025-03-09 09:42:03'),
(295, 18, 'TRX-20250309174952', '2025-03-09', NULL, '2025-03-09 09:49:55', '2025-03-09 09:49:55'),
(296, 18, 'TRX-20250309175111', '2025-03-09', NULL, '2025-03-09 09:51:14', '2025-03-09 09:51:14'),
(297, 18, 'TRX-20250309175241', '2025-03-09', NULL, '2025-03-09 09:52:46', '2025-03-09 09:52:46'),
(298, 9, 'TRX-20250309231651', '2025-03-09', NULL, '2025-03-09 15:16:53', '2025-03-09 15:16:53'),
(299, 9, 'TRX-20250309231938', '2025-03-09', NULL, '2025-03-09 15:19:40', '2025-03-09 15:19:40'),
(300, 9, 'TRX-20250309232053', '2025-03-09', NULL, '2025-03-09 15:20:55', '2025-03-09 15:20:55'),
(301, 9, 'TRX-20250309232302', '2025-03-09', NULL, '2025-03-09 15:23:03', '2025-03-09 15:23:03'),
(302, 9, 'TRX-20250309232355', '2025-03-09', NULL, '2025-03-09 15:23:57', '2025-03-09 15:23:57'),
(303, 9, 'TRX-20250309235129', '2025-03-09', NULL, '2025-03-09 15:51:31', '2025-03-09 15:51:31'),
(304, 18, 'TRX-20250309235214', '2025-03-09', NULL, '2025-03-09 15:52:19', '2025-03-09 15:52:19'),
(305, 10, 'TRX-20250309235414', '2025-03-09', NULL, '2025-03-09 15:54:19', '2025-03-09 15:54:19'),
(306, 18, 'TRX-20250310000353', '2025-03-10', NULL, '2025-03-09 16:03:57', '2025-03-09 16:03:57'),
(307, 9, 'TRX-20250310000424', '2025-03-10', NULL, '2025-03-09 16:04:26', '2025-03-09 16:04:26'),
(308, 9, 'TRX-20250310001052', '2025-03-10', NULL, '2025-03-09 16:10:54', '2025-03-09 16:10:54'),
(309, 12, 'TRX-20250310001128', '2025-03-10', NULL, '2025-03-09 16:11:33', '2025-03-09 16:11:33'),
(310, 9, 'TRX-20250310001302', '2025-03-10', NULL, '2025-03-09 16:13:03', '2025-03-09 16:13:03'),
(311, 9, 'TRX-20250310001754', '2025-03-10', NULL, '2025-03-09 16:17:56', '2025-03-09 16:17:56'),
(312, 9, 'TRX-20250310002105', '2025-03-10', NULL, '2025-03-09 16:21:07', '2025-03-09 16:21:07'),
(313, 9, 'TRX-20250310002223', '2025-03-10', NULL, '2025-03-09 16:22:24', '2025-03-09 16:22:24'),
(314, 9, 'TRX-20250310002506', '2025-03-10', NULL, '2025-03-09 16:25:07', '2025-03-09 16:25:07'),
(315, 9, 'TRX-20250310003016', '2025-03-10', NULL, '2025-03-09 16:30:18', '2025-03-09 16:30:18'),
(316, 18, 'TRX-20250310005410', '2025-03-10', NULL, '2025-03-09 16:54:16', '2025-03-09 16:54:16'),
(317, 18, 'TRX-20250310005614', '2025-03-10', NULL, '2025-03-09 16:56:19', '2025-03-09 16:56:19'),
(318, 18, 'TRX-20250310005746', '2025-03-10', NULL, '2025-03-09 16:57:55', '2025-03-09 16:57:55'),
(319, 9, 'TRX-20250310005906', '2025-03-10', NULL, '2025-03-09 16:59:10', '2025-03-09 16:59:10'),
(320, 9, 'TRX-20250310010005', '2025-03-10', NULL, '2025-03-09 17:00:07', '2025-03-09 17:00:07'),
(321, 18, 'TRX-20250310010118', '2025-03-10', NULL, '2025-03-09 17:01:22', '2025-03-09 17:01:22'),
(322, 18, 'TRX-20250310010707', '2025-03-10', NULL, '2025-03-09 17:07:14', '2025-03-09 17:07:14'),
(323, 9, 'TRX-20250310010836', '2025-03-10', NULL, '2025-03-09 17:08:39', '2025-03-09 17:08:39'),
(324, 9, 'TRX-20250310011108', '2025-03-10', NULL, '2025-03-09 17:11:12', '2025-03-09 17:11:12'),
(325, 9, 'TRX-20250310011123', '2025-03-10', NULL, '2025-03-09 17:11:25', '2025-03-09 17:11:25'),
(326, 9, 'TRX-20250310011356', '2025-03-10', NULL, '2025-03-09 17:13:58', '2025-03-09 17:13:58'),
(327, 12, 'TRX-20250310011433', '2025-03-07', NULL, '2025-03-09 17:14:50', '2025-03-09 17:14:50'),
(328, 9, 'TRX-20250310011544', '2025-03-10', NULL, '2025-03-09 17:15:45', '2025-03-09 17:15:45'),
(329, 9, 'TRX-20250310011625', '2025-03-10', NULL, '2025-03-09 17:16:26', '2025-03-09 17:16:26'),
(330, 9, 'TRX-20250310011941', '2025-03-10', NULL, '2025-03-09 17:19:44', '2025-03-09 17:19:44'),
(331, 9, 'TRX-20250310013100', '2025-03-10', NULL, '2025-03-09 17:31:01', '2025-03-09 17:31:01'),
(332, 9, 'TRX-20250310013201', '2025-03-10', NULL, '2025-03-09 17:32:02', '2025-03-09 17:32:02'),
(333, 18, 'TRX-20250310013330', '2025-03-10', NULL, '2025-03-09 17:33:36', '2025-03-09 17:33:36'),
(334, 9, 'TRX-20250310013345', '2025-03-10', NULL, '2025-03-09 17:33:46', '2025-03-09 17:33:46'),
(335, 18, 'TRX-20250310013730', '2025-03-10', NULL, '2025-03-09 17:37:36', '2025-03-09 17:37:36'),
(336, 9, 'TRX-20250310013758', '2025-03-10', NULL, '2025-03-09 17:38:00', '2025-03-09 17:38:00'),
(337, 9, 'TRX-20250310103802', '2025-03-10', NULL, '2025-03-10 02:38:04', '2025-03-10 02:38:04'),
(338, 9, 'TRX-20250310103825', '2025-03-10', NULL, '2025-03-10 02:38:26', '2025-03-10 02:38:26'),
(339, 9, 'TRX-20250310104234', '2025-03-10', NULL, '2025-03-10 02:42:36', '2025-03-10 02:42:36'),
(340, 9, 'TRX-20250310104416', '2025-03-10', NULL, '2025-03-10 02:44:18', '2025-03-10 02:44:18'),
(341, 9, 'TRX-20250310104538', '2025-03-10', NULL, '2025-03-10 02:45:39', '2025-03-10 02:45:39'),
(342, 9, 'TRX-20250310105602', '2025-03-10', NULL, '2025-03-10 02:56:03', '2025-03-10 02:56:03'),
(343, 9, 'TRX-20250310105618', '2025-03-10', NULL, '2025-03-10 02:56:20', '2025-03-10 02:56:20'),
(344, 9, 'TRX-20250310105701', '2025-03-10', NULL, '2025-03-10 02:57:02', '2025-03-10 02:57:02'),
(345, 9, 'TRX-20250310110304', '2025-03-10', NULL, '2025-03-10 03:03:04', '2025-03-10 03:03:04'),
(346, 9, 'TRX-20250310110432', '2025-03-10', NULL, '2025-03-10 03:04:33', '2025-03-10 03:04:33'),
(347, 9, 'TRX-20250310110653', '2025-03-10', NULL, '2025-03-10 03:06:55', '2025-03-10 03:06:55'),
(348, 9, 'TRX-20250310110850', '2025-03-10', NULL, '2025-03-10 03:08:51', '2025-03-10 03:08:51'),
(349, 9, 'TRX-20250310111634', '2025-03-10', NULL, '2025-03-10 03:16:35', '2025-03-10 03:16:35'),
(350, 9, 'TRX-20250310111719', '2025-03-10', NULL, '2025-03-10 03:17:20', '2025-03-10 03:17:20'),
(351, 9, 'TRX-20250310112204', '2025-03-10', NULL, '2025-03-10 03:22:06', '2025-03-10 03:22:06'),
(352, 9, 'TRX-20250310112319', '2025-03-10', NULL, '2025-03-10 03:23:20', '2025-03-10 03:23:20'),
(353, 9, 'TRX-20250310112538', '2025-03-10', NULL, '2025-03-10 03:25:39', '2025-03-10 03:25:39'),
(354, 9, 'TRX-20250310112959', '2025-03-10', NULL, '2025-03-10 03:30:00', '2025-03-10 03:30:00'),
(355, 9, 'TRX-20250310113916', '2025-03-10', NULL, '2025-03-10 03:39:18', '2025-03-10 03:39:18'),
(356, 9, 'TRX-20250310114556', '2025-03-10', NULL, '2025-03-10 03:45:58', '2025-03-10 03:45:58'),
(357, 9, 'TRX-20250310114650', '2025-03-10', NULL, '2025-03-10 03:46:52', '2025-03-10 03:46:52'),
(358, 18, 'TRX-20250310122919', '2025-03-10', NULL, '2025-03-10 04:29:24', '2025-03-10 04:29:24'),
(359, 9, 'TRX-20250310123109', '2025-03-10', NULL, '2025-03-10 04:31:10', '2025-03-10 04:31:10'),
(360, 9, 'TRX-20250310124256', '2025-03-10', NULL, '2025-03-10 04:42:58', '2025-03-10 04:42:58'),
(361, 9, 'TRX-20250310124339', '2025-03-10', NULL, '2025-03-10 04:43:40', '2025-03-10 04:43:40'),
(362, 9, 'TRX-20250310124554', '2025-03-10', NULL, '2025-03-10 04:45:55', '2025-03-10 04:45:55'),
(363, 9, 'TRX-20250310124644', '2025-03-10', NULL, '2025-03-10 04:46:46', '2025-03-10 04:46:46'),
(364, 9, 'TRX-20250310125306', '2025-03-10', NULL, '2025-03-10 04:53:07', '2025-03-10 04:53:07'),
(365, 9, 'TRX-20250310125446', '2025-03-10', NULL, '2025-03-10 04:54:48', '2025-03-10 04:54:48'),
(366, 9, 'TRX-20250310125513', '2025-03-10', NULL, '2025-03-10 04:55:15', '2025-03-10 04:55:15'),
(367, 9, 'TRX-20250310125617', '2025-03-10', NULL, '2025-03-10 04:56:19', '2025-03-10 04:56:19'),
(368, 12, 'TRX-20250310130446', '2025-03-10', NULL, '2025-03-10 05:04:50', '2025-03-10 05:04:50'),
(369, 9, 'TRX-20250310130710', '2025-03-10', NULL, '2025-03-10 05:07:11', '2025-03-10 05:07:11'),
(370, 9, 'TRX-20250310131031', '2025-03-10', NULL, '2025-03-10 05:10:33', '2025-03-10 05:10:33'),
(371, 9, 'TRX-20250310131411', '2025-03-10', NULL, '2025-03-10 05:14:12', '2025-03-10 05:14:12'),
(372, 9, 'TRX-20250310131507', '2025-03-10', NULL, '2025-03-10 05:15:09', '2025-03-10 05:15:09'),
(373, 9, 'TRX-20250310132426', '2025-03-10', NULL, '2025-03-10 05:24:28', '2025-03-10 05:24:28'),
(374, 9, 'TRX-20250310133959', '2025-03-10', NULL, '2025-03-10 05:40:01', '2025-03-10 05:40:01'),
(375, 9, 'TRX-20250310134031', '2025-03-10', NULL, '2025-03-10 05:40:32', '2025-03-10 05:40:32'),
(376, 9, 'TRX-20250310134051', '2025-03-10', NULL, '2025-03-10 05:40:52', '2025-03-10 05:40:52'),
(377, 9, 'TRX-20250310134118', '2025-03-10', NULL, '2025-03-10 05:41:19', '2025-03-10 05:41:19'),
(378, 9, 'TRX-20250310134450', '2025-03-10', NULL, '2025-03-10 05:44:56', '2025-03-10 05:44:56'),
(379, 18, 'TRX-20250310134601', '2025-03-10', NULL, '2025-03-10 05:46:06', '2025-03-10 05:46:06'),
(380, 9, 'TRX-20250310134737', '2025-03-10', NULL, '2025-03-10 05:47:38', '2025-03-10 05:47:38'),
(381, 9, 'TRX-20250310135206', '2025-03-10', NULL, '2025-03-10 05:52:13', '2025-03-10 05:52:13'),
(382, 9, 'TRX-20250310135421', '2025-03-10', NULL, '2025-03-10 05:54:22', '2025-03-10 05:54:22'),
(383, 9, 'TRX-20250310141135', '2025-03-10', NULL, '2025-03-10 06:11:36', '2025-03-10 06:11:36'),
(384, 9, 'TRX-20250310141609', '2025-03-10', NULL, '2025-03-10 06:16:10', '2025-03-10 06:16:10'),
(385, 9, 'TRX-20250310141758', '2025-03-10', NULL, '2025-03-10 06:17:59', '2025-03-10 06:17:59'),
(386, 9, 'TRX-20250310142131', '2025-03-10', NULL, '2025-03-10 06:21:32', '2025-03-10 06:21:32'),
(387, 9, 'TRX-20250310142504', '2025-03-10', NULL, '2025-03-10 06:25:05', '2025-03-10 06:25:05'),
(388, 9, 'TRX-20250310142511', '2025-03-10', NULL, '2025-03-10 06:25:13', '2025-03-10 06:25:13'),
(389, 9, 'TRX-20250310142724', '2025-03-10', NULL, '2025-03-10 06:27:25', '2025-03-10 06:27:25'),
(390, 9, 'TRX-20250310142755', '2025-03-10', NULL, '2025-03-10 06:27:57', '2025-03-10 06:27:57'),
(391, 9, 'TRX-20250310143444', '2025-03-10', NULL, '2025-03-10 06:34:46', '2025-03-10 06:34:46'),
(392, 9, 'TRX-20250310143948', '2025-03-10', NULL, '2025-03-10 06:39:50', '2025-03-10 06:39:50'),
(393, 9, 'TRX-20250310144030', '2025-03-10', NULL, '2025-03-10 06:40:32', '2025-03-10 06:40:32'),
(394, 9, 'TRX-20250310144402', '2025-03-10', NULL, '2025-03-10 06:44:03', '2025-03-10 06:44:03'),
(395, 9, 'TRX-20250310144453', '2025-03-10', NULL, '2025-03-10 06:44:55', '2025-03-10 06:44:55'),
(396, 9, 'TRX-20250310144508', '2025-03-10', NULL, '2025-03-10 06:45:09', '2025-03-10 06:45:09'),
(397, 9, 'TRX-20250310144539', '2025-03-10', NULL, '2025-03-10 06:45:40', '2025-03-10 06:45:40'),
(398, 12, 'TRX-20250311140532', '2025-03-11', NULL, '2025-03-11 06:05:39', '2025-03-11 06:05:39'),
(399, 9, 'TRX-20250311141427', '2025-03-11', NULL, '2025-03-11 06:14:29', '2025-03-11 06:14:29'),
(400, 9, 'TRX-20250319014602', '2025-03-19', NULL, '2025-03-18 17:46:04', '2025-03-18 17:46:04'),
(401, 9, 'TRX-20250319015313', '2025-03-19', NULL, '2025-03-18 17:53:16', '2025-03-18 17:53:16'),
(402, 9, 'TRX-20250319152301', '2025-03-19', NULL, '2025-03-19 07:23:03', '2025-03-19 07:23:03'),
(403, 9, 'TRX-20250319152403', '2025-03-19', NULL, '2025-03-19 07:24:14', '2025-03-19 07:24:14'),
(404, 9, 'TRX-20250319201415', '2025-03-19', NULL, '2025-03-19 12:14:17', '2025-03-19 12:14:17'),
(405, 9, 'TRX-20250319201431', '2025-03-19', NULL, '2025-03-19 12:14:32', '2025-03-19 12:14:32'),
(406, 9, 'TRX-20250319201451', '2025-03-19', NULL, '2025-03-19 12:14:52', '2025-03-19 12:14:52'),
(407, 9, 'TRX-20250319203655', '2025-03-19', NULL, '2025-03-19 12:36:58', '2025-03-19 12:36:58'),
(408, 10, 'TRX-20250319232326', '2025-03-19', NULL, '2025-03-19 15:23:34', '2025-03-19 15:23:34'),
(409, 9, 'TRX-20250322135754', '2025-03-22', NULL, '2025-03-22 05:57:59', '2025-03-22 05:57:59'),
(410, 12, 'TRX-20250322135852', '2025-03-13', NULL, '2025-03-22 05:59:01', '2025-03-22 05:59:01');

-- --------------------------------------------------------

--
-- Table structure for table `delivery_items`
--

CREATE TABLE `delivery_items` (
  `delivery_item_id` int NOT NULL,
  `delivery_id` int NOT NULL,
  `product_id` int NOT NULL,
  `quantity` int NOT NULL,
  `expiration_date` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `delivery_items`
--

INSERT INTO `delivery_items` (`delivery_item_id`, `delivery_id`, `product_id`, `quantity`, `expiration_date`) VALUES
(156, 358, 45, 100, '2025-03-20'),
(157, 359, 45, 100, '2025-03-10'),
(158, 360, 45, 100, '2025-03-10'),
(159, 361, 45, 500, '2025-03-10'),
(160, 362, 45, 100, '2025-03-10'),
(161, 363, 45, 500, '2025-03-10'),
(162, 364, 46, 100, '2025-03-10'),
(163, 365, 46, 200, '2025-03-10'),
(164, 366, 46, 1000, '2025-03-10'),
(165, 367, 46, 1000, '2025-03-10'),
(166, 368, 47, 100, '2025-03-10'),
(167, 369, 47, 100, '2025-03-10'),
(168, 370, 47, 100, '2025-03-10'),
(169, 371, 47, 500, '2025-03-10'),
(170, 372, 48, 1, '2025-03-10'),
(171, 373, 47, 100, '2025-03-13'),
(172, 374, 47, 100, '2025-03-10'),
(173, 375, 48, 100, '2025-03-10'),
(174, 376, 48, 100, '2025-03-10'),
(175, 377, 48, 100, '2025-03-20'),
(176, 378, 48, 100, '2025-03-27'),
(177, 379, 48, 1000, '2025-03-24'),
(178, 380, 48, 100, '2025-03-24'),
(179, 381, 48, 1000000, '2025-03-10'),
(180, 382, 48, 1, '2025-03-10'),
(181, 383, 47, 100, '2025-03-10'),
(182, 384, 47, 9, '2025-03-10'),
(183, 385, 47, 100, '2025-03-10'),
(184, 386, 47, 100, '2025-03-19'),
(185, 388, 47, 9, '2025-03-19'),
(186, 389, 47, 100, '2025-03-12'),
(187, 390, 47, 100, '2025-03-13'),
(188, 391, 47, 100, '2025-03-24'),
(189, 392, 47, 500, '2025-03-28'),
(190, 393, 46, 1000, '2025-03-24'),
(191, 394, 47, 100000, '2025-03-21'),
(192, 395, 47, 1000000000, '2025-03-10'),
(193, 396, 47, 100000000, '2025-03-10'),
(194, 397, 47, 1, '2025-03-10'),
(195, 398, 47, 100, '2025-03-20'),
(196, 399, 47, 1, '2025-03-26'),
(197, 400, 46, 123, '2025-03-19'),
(198, 402, 46, 123, '2025-03-19'),
(199, 404, 46, 123, '2025-03-19'),
(200, 405, 46, 909, '2025-03-19'),
(201, 406, 46, 909, '2025-03-19'),
(202, 407, 46, 100000, '2025-03-19'),
(203, 408, 46, 2, '2025-03-19');

-- --------------------------------------------------------

--
-- Table structure for table `discounts`
--

CREATE TABLE `discounts` (
  `discount_id` int NOT NULL,
  `discount_name` varchar(50) COLLATE utf8mb4_general_ci NOT NULL,
  `discount_rate` decimal(5,2) NOT NULL,
  `start_date` date DEFAULT NULL,
  `end_date` date DEFAULT NULL,
  `created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ;

--
-- Dumping data for table `discounts`
--

INSERT INTO `discounts` (`discount_id`, `discount_name`, `discount_rate`, `start_date`, `end_date`, `created_at`, `updated_at`) VALUES
(15, 'test1', '10.00', NULL, NULL, '2025-03-10 04:32:23', '2025-03-10 04:32:23');

-- --------------------------------------------------------

--
-- Table structure for table `inventory`
--

CREATE TABLE `inventory` (
  `inventory_id` int NOT NULL,
  `product_id` int NOT NULL,
  `change_type` enum('received','sold') NOT NULL,
  `quantity` int NOT NULL,
  `change_date` timestamp NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `inventory`
--

INSERT INTO `inventory` (`inventory_id`, `product_id`, `change_type`, `quantity`, `change_date`) VALUES
(1, 45, 'received', 0, '2025-03-22 13:55:08'),
(2, 46, 'received', 0, '2025-03-22 13:55:08'),
(3, 47, 'received', 0, '2025-03-22 13:55:08'),
(4, 48, 'received', 0, '2025-03-22 13:55:08');

-- --------------------------------------------------------

--
-- Table structure for table `loghistory`
--

CREATE TABLE `loghistory` (
  `LogID` int NOT NULL,
  `Role` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `FullName` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `Action` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `Date` datetime DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `loghistory`
--

INSERT INTO `loghistory` (`LogID`, `Role`, `FullName`, `Action`, `Date`) VALUES
(1, 'Admin', 'Administrator', 'Login', '2025-03-06 17:27:33'),
(2, 'Admin', 'Administrator', 'Login', '2025-03-06 17:28:10'),
(3, 'Cashier', 'leemar macalinga', 'Login', '2025-03-06 17:41:17'),
(4, 'Admin', 'Administrator', 'Login', '2025-03-06 17:58:08'),
(5, 'Admin', 'Administrator', 'Login', '2025-03-06 18:10:31'),
(6, 'Admin', 'Administrator', 'Login', '2025-03-06 18:11:58'),
(7, 'Admin', 'Administrator', 'Login', '2025-03-06 18:13:29'),
(8, 'Admin', 'Administrator', 'Login', '2025-03-06 18:15:48'),
(9, 'Admin', 'Administrator', 'Login', '2025-03-06 18:18:47'),
(10, 'Admin', 'Administrator', 'Login', '2025-03-06 18:22:19'),
(11, 'Admin', 'Administrator', 'Login', '2025-03-06 18:25:47'),
(12, 'Admin', 'Administrator', 'Login', '2025-03-06 18:26:58'),
(13, 'Admin', 'Administrator', 'Login', '2025-03-06 18:28:42'),
(14, 'Admin', 'Administrator', 'Login', '2025-03-06 18:41:44'),
(15, 'Admin', 'Administrator', 'Login', '2025-03-06 18:46:03'),
(16, 'Admin', 'Administrator', 'Login', '2025-03-06 18:47:51'),
(17, 'Admin', 'Administrator', 'Login', '2025-03-06 18:50:43'),
(18, 'Admin', 'Administrator', 'Login', '2025-03-06 18:53:28'),
(19, 'Admin', 'Administrator', 'Login', '2025-03-06 18:56:53'),
(20, 'Admin', 'Administrator', 'Login', '2025-03-06 19:00:27'),
(21, 'Admin', 'Administrator', 'Login', '2025-03-07 10:05:27'),
(22, 'Admin', 'Administrator', 'Login', '2025-03-07 10:54:06'),
(23, 'Admin', 'Administrator', 'Login', '2025-03-07 10:59:53'),
(24, 'Admin', 'Administrator', 'Login', '2025-03-07 11:07:57'),
(25, 'Admin', 'Administrator', 'Login', '2025-03-07 11:12:06'),
(26, 'Admin', 'Administrator', 'Login', '2025-03-07 11:12:20'),
(27, 'Admin', 'Administrator', 'Login', '2025-03-07 16:32:57'),
(28, 'Admin', 'Administrator', 'Login', '2025-03-07 16:33:48'),
(29, 'Admin', 'Administrator', 'Login', '2025-03-07 16:35:39'),
(30, 'Admin', 'Administrator', 'Login', '2025-03-07 16:36:23'),
(31, 'Admin', 'Administrator', 'Login', '2025-03-07 20:02:40'),
(32, 'Admin', 'Administrator', 'Login', '2025-03-07 20:08:20'),
(33, 'Admin', 'Administrator', 'Login', '2025-03-07 20:09:41'),
(34, 'Admin', 'Administrator', 'Login', '2025-03-07 20:21:37'),
(35, 'Admin', 'Administrator', 'Login', '2025-03-07 20:43:43'),
(36, 'Admin', 'Administrator', 'Login', '2025-03-07 20:54:52'),
(37, 'Admin', 'Administrator', 'Login', '2025-03-07 20:56:52'),
(38, 'Admin', 'Administrator', 'Login', '2025-03-07 20:57:21'),
(39, 'Admin', 'Administrator', 'Login', '2025-03-07 20:59:59'),
(40, 'Admin', 'Administrator', 'Login', '2025-03-07 21:00:42'),
(41, 'Admin', 'Administrator', 'Login', '2025-03-07 21:00:53'),
(42, 'Admin', 'Administrator', 'Login', '2025-03-07 21:01:47'),
(43, 'Admin', 'Administrator', 'Login', '2025-03-07 21:02:11'),
(44, 'Admin', 'Administrator', 'Login', '2025-03-07 21:03:20'),
(45, 'Admin', 'Administrator', 'Login', '2025-03-07 21:04:12'),
(46, 'Admin', 'Administrator', 'Login', '2025-03-07 21:04:45'),
(47, 'Admin', 'Administrator', 'Login', '2025-03-07 21:07:59'),
(48, 'Admin', 'Administrator', 'Login', '2025-03-07 21:22:19'),
(49, 'Admin', 'Administrator', 'Login', '2025-03-07 21:28:09'),
(50, 'Admin', 'Administrator', 'Login', '2025-03-07 21:29:39'),
(51, 'Admin', 'Administrator', 'Login', '2025-03-07 21:31:40'),
(52, 'Admin', 'Administrator', 'Login', '2025-03-07 21:33:44'),
(53, 'Admin', 'Administrator', 'Login', '2025-03-07 21:37:34'),
(54, 'Admin', 'Administrator', 'Login', '2025-03-07 21:46:15'),
(55, 'Admin', 'Administrator', 'Login', '2025-03-07 21:48:23'),
(56, 'Admin', 'Administrator', 'Login', '2025-03-07 21:49:06'),
(57, 'Admin', 'Administrator', 'Login', '2025-03-07 21:50:51'),
(58, 'Admin', 'Administrator', 'Login', '2025-03-07 22:03:41'),
(59, 'Admin', 'Administrator', 'Login', '2025-03-07 22:04:08'),
(60, 'Admin', 'Administrator', 'Login', '2025-03-07 22:04:33'),
(61, 'Admin', 'Administrator', 'Login', '2025-03-07 22:04:52'),
(62, 'Admin', 'Administrator', 'Login', '2025-03-07 22:07:46'),
(63, 'Admin', 'Administrator', 'Login', '2025-03-07 22:09:32'),
(64, 'Admin', 'Administrator', 'Login', '2025-03-07 22:15:17'),
(65, 'Admin', 'Administrator', 'Login', '2025-03-07 22:16:11'),
(66, 'Admin', 'Administrator', 'Login', '2025-03-07 22:19:49'),
(67, 'Admin', 'Administrator', 'Login', '2025-03-07 22:26:28'),
(68, 'Admin', 'Administrator', 'Login', '2025-03-07 22:27:36'),
(69, 'Admin', 'Administrator', 'Login', '2025-03-07 22:28:16'),
(70, 'Admin', 'Administrator', 'Login', '2025-03-07 22:29:13'),
(71, 'Admin', 'Administrator', 'Login', '2025-03-07 22:29:29'),
(72, 'Admin', 'Administrator', 'Login', '2025-03-07 22:29:58'),
(73, 'Admin', 'Administrator', 'Login', '2025-03-07 22:30:30'),
(74, 'Admin', 'Administrator', 'Login', '2025-03-07 22:32:00'),
(75, 'Admin', 'Administrator', 'Login', '2025-03-07 22:33:04'),
(76, 'Admin', 'Administrator', 'Login', '2025-03-07 22:33:29'),
(77, 'Admin', 'Administrator', 'Login', '2025-03-07 22:34:08'),
(78, 'Admin', 'Administrator', 'Login', '2025-03-07 22:34:59'),
(79, 'Admin', 'Administrator', 'Login', '2025-03-07 22:35:09'),
(80, 'Admin', 'Administrator', 'Login', '2025-03-07 22:39:06'),
(81, 'Admin', 'Administrator', 'Login', '2025-03-07 22:40:47'),
(82, 'Admin', 'Administrator', 'Login', '2025-03-07 22:41:10'),
(83, 'Admin', 'Administrator', 'Login', '2025-03-07 22:41:23'),
(84, 'Admin', 'Administrator', 'Login', '2025-03-07 22:42:18'),
(85, 'Admin', 'Administrator', 'Login', '2025-03-07 22:57:53'),
(86, 'Admin', 'Administrator', 'Login', '2025-03-07 22:58:54'),
(87, 'Admin', 'Administrator', 'Login', '2025-03-07 23:00:38'),
(88, 'Admin', 'Administrator', 'Login', '2025-03-07 23:11:51'),
(89, 'Admin', 'Administrator', 'Login', '2025-03-07 23:12:47'),
(90, 'Admin', 'Administrator', 'Login', '2025-03-07 23:15:55'),
(91, 'Admin', 'Administrator', 'Login', '2025-03-07 23:17:01'),
(92, 'Admin', 'Administrator', 'Login', '2025-03-07 23:18:15'),
(93, 'Admin', 'Administrator', 'Login', '2025-03-07 23:22:22'),
(94, 'Admin', 'Administrator', 'Login', '2025-03-07 23:22:44'),
(95, 'Admin', 'Administrator', 'Login', '2025-03-07 23:22:57'),
(96, 'Admin', 'Administrator', 'Login', '2025-03-07 23:26:23'),
(97, 'Admin', 'Administrator', 'Login', '2025-03-07 23:26:42'),
(98, 'Admin', 'Administrator', 'Login', '2025-03-07 23:27:12'),
(99, 'Admin', 'Administrator', 'Login', '2025-03-07 23:27:48'),
(100, 'Admin', 'Administrator', 'Login', '2025-03-07 23:28:35'),
(101, 'Admin', 'Administrator', 'Login', '2025-03-07 23:29:05'),
(102, 'Admin', 'Administrator', 'Login', '2025-03-07 23:29:31'),
(103, 'Admin', 'Administrator', 'Login', '2025-03-07 23:32:49'),
(104, 'Admin', 'Administrator', 'Login', '2025-03-07 23:36:38'),
(105, 'Admin', 'Administrator', 'Login', '2025-03-07 23:37:11'),
(106, 'Admin', 'Administrator', 'Login', '2025-03-07 23:37:35'),
(107, 'Admin', 'Administrator', 'Login', '2025-03-07 23:37:52'),
(108, 'Admin', 'Administrator', 'Login', '2025-03-07 23:38:08'),
(109, 'Admin', 'Administrator', 'Login', '2025-03-07 23:38:47'),
(110, 'Admin', 'Administrator', 'Login', '2025-03-07 23:39:06'),
(111, 'Admin', 'Administrator', 'Login', '2025-03-07 23:39:45'),
(112, 'Admin', 'Administrator', 'Login', '2025-03-07 23:43:28'),
(113, 'Admin', 'Administrator', 'Login', '2025-03-07 23:45:10'),
(114, 'Admin', 'Administrator', 'Login', '2025-03-07 23:49:33'),
(115, 'Admin', 'Administrator', 'Login', '2025-03-07 23:50:20'),
(116, 'Admin', 'Administrator', 'Login', '2025-03-07 23:51:37'),
(117, 'Admin', 'Administrator', 'Login', '2025-03-07 23:53:00'),
(118, 'Admin', 'Administrator', 'Login', '2025-03-07 23:53:16'),
(119, 'Admin', 'Administrator', 'Login', '2025-03-07 23:54:29'),
(120, 'Admin', 'Administrator', 'Login', '2025-03-07 23:55:50'),
(121, 'Admin', 'Administrator', 'Login', '2025-03-07 23:56:09'),
(122, 'Admin', 'Administrator', 'Login', '2025-03-07 23:57:34'),
(123, 'Admin', 'Administrator', 'Login', '2025-03-07 23:58:37'),
(124, 'Admin', 'Administrator', 'Login', '2025-03-07 23:59:43'),
(125, 'Admin', 'Administrator', 'Login', '2025-03-07 23:59:54'),
(126, 'Admin', 'Administrator', 'Login', '2025-03-08 00:00:22'),
(127, 'Admin', 'Administrator', 'Login', '2025-03-08 00:00:34'),
(128, 'Admin', 'Administrator', 'Login', '2025-03-08 00:00:43'),
(129, 'Admin', 'Administrator', 'Login', '2025-03-08 00:03:36'),
(130, 'Admin', 'Administrator', 'Login', '2025-03-08 00:05:31'),
(131, 'Admin', 'Administrator', 'Login', '2025-03-08 00:07:04'),
(132, 'Admin', 'Administrator', 'Login', '2025-03-08 00:07:17'),
(133, 'Staff', '', 'Login', '2025-03-08 00:07:37'),
(134, 'Admin', 'Administrator', 'Login', '2025-03-08 00:11:31'),
(135, 'Admin', 'Administrator', 'Login', '2025-03-08 00:11:58'),
(136, 'Admin', 'Administrator', 'Login', '2025-03-08 00:31:03'),
(137, 'Admin', 'Administrator', 'Login', '2025-03-08 00:35:15'),
(138, 'Admin', 'Administrator', 'Login', '2025-03-08 00:36:29'),
(139, 'Admin', 'Administrator', 'Login', '2025-03-08 00:36:45'),
(140, 'Admin', 'Administrator', 'Login', '2025-03-08 00:37:31'),
(141, 'Admin', 'Administrator', 'Login', '2025-03-08 00:41:50'),
(142, 'Admin', 'Administrator', 'Login', '2025-03-08 00:43:22'),
(143, 'Admin', 'Administrator', 'Login', '2025-03-08 00:43:48'),
(144, 'Admin', 'Administrator', 'Login', '2025-03-08 00:44:13'),
(145, 'Admin', 'Administrator', 'Login', '2025-03-08 00:45:28'),
(146, 'Admin', 'Administrator', 'Login', '2025-03-08 00:51:29'),
(147, 'Admin', 'Administrator', 'Login', '2025-03-08 00:54:22'),
(148, 'Admin', 'Administrator', 'Login', '2025-03-08 00:56:19'),
(149, 'Admin', 'Administrator', 'Login', '2025-03-08 00:57:46'),
(150, 'Admin', 'Administrator', 'Login', '2025-03-08 00:58:35'),
(151, 'Admin', 'Administrator', 'Login', '2025-03-08 00:58:59'),
(152, 'Admin', 'Administrator', 'Login', '2025-03-08 01:00:33'),
(153, 'Admin', 'Administrator', 'Login', '2025-03-08 01:02:35'),
(154, 'Admin', 'Administrator', 'Login', '2025-03-08 01:03:27'),
(155, 'Admin', 'Administrator', 'Login', '2025-03-08 01:04:14'),
(156, 'Admin', 'Administrator', 'Login', '2025-03-08 01:13:06'),
(157, 'Admin', 'Administrator', 'Login', '2025-03-08 01:17:00'),
(158, 'Admin', 'Administrator', 'Login', '2025-03-08 01:19:05'),
(159, 'Admin', 'Administrator', 'Login', '2025-03-08 01:20:19'),
(160, 'Admin', 'Administrator', 'Login', '2025-03-08 01:21:13'),
(161, 'Admin', 'Administrator', 'Login', '2025-03-08 01:22:43'),
(162, 'Admin', 'Administrator', 'Login', '2025-03-08 01:25:08'),
(163, 'Admin', 'Administrator', 'Login', '2025-03-08 01:28:02'),
(164, 'Admin', 'Administrator', 'Login', '2025-03-08 01:29:42'),
(165, 'Admin', 'Administrator', 'Login', '2025-03-08 01:30:58'),
(166, 'Admin', 'Administrator', 'Login', '2025-03-08 01:33:16'),
(167, 'Admin', 'Administrator', 'Login', '2025-03-08 01:34:37'),
(168, 'Admin', 'Administrator', 'Login', '2025-03-08 01:38:19'),
(169, 'Admin', 'Administrator', 'Login', '2025-03-08 01:40:28'),
(170, 'Admin', 'Administrator', 'Login', '2025-03-08 01:41:51'),
(171, 'Admin', 'Administrator', 'Login', '2025-03-08 01:42:47'),
(172, 'Admin', 'Administrator', 'Login', '2025-03-08 01:47:44'),
(173, 'Admin', 'Administrator', 'Login', '2025-03-08 01:49:35'),
(174, 'Admin', 'Administrator', 'Login', '2025-03-08 01:50:00'),
(175, 'Admin', 'Administrator', 'Login', '2025-03-08 01:50:19'),
(176, 'Admin', 'Administrator', 'Login', '2025-03-08 01:50:40'),
(177, 'Admin', 'Administrator', 'Login', '2025-03-08 01:53:42'),
(178, 'Admin', 'Administrator', 'Login', '2025-03-08 01:57:09'),
(179, 'Admin', 'Administrator', 'Login', '2025-03-08 01:58:25'),
(180, 'Admin', 'Administrator', 'Login', '2025-03-08 01:58:45'),
(181, 'Admin', 'Administrator', 'Login', '2025-03-08 02:00:41'),
(182, 'Admin', 'Administrator', 'Login', '2025-03-08 02:03:41'),
(183, 'Admin', 'Administrator', 'Login', '2025-03-08 02:05:37'),
(184, 'Admin', 'Administrator', 'Login', '2025-03-08 02:10:15'),
(185, 'Admin', 'Administrator', 'Login', '2025-03-08 02:11:16'),
(186, 'Admin', 'Administrator', 'Login', '2025-03-08 02:12:11'),
(187, 'Admin', 'Administrator', 'Login', '2025-03-08 02:12:22'),
(188, 'Staff', '', 'Login', '2025-03-08 02:12:51'),
(189, 'Admin', 'Administrator', 'Login', '2025-03-08 02:13:08'),
(190, 'Admin', 'Administrator', 'Login', '2025-03-08 02:15:06'),
(191, 'Admin', 'Administrator', 'Login', '2025-03-08 02:17:08'),
(192, 'Admin', 'Administrator', 'Login', '2025-03-09 09:27:20'),
(193, 'Cashier', '', 'Login', '2025-03-09 09:29:42'),
(194, 'Cashier', '', 'Login', '2025-03-09 09:33:22'),
(195, 'Admin', 'Administrator', 'Login', '2025-03-09 09:34:27'),
(196, 'Admin', 'Administrator', 'Login', '2025-03-09 09:34:43'),
(197, 'Admin', 'Administrator', 'Login', '2025-03-09 09:37:22'),
(198, 'Admin', 'Administrator', 'Login', '2025-03-09 09:38:39'),
(199, 'Admin', 'Administrator', 'Login', '2025-03-09 09:40:02'),
(200, 'Admin', 'Administrator', 'Login', '2025-03-09 09:42:48'),
(201, 'Admin', 'Administrator', 'Login', '2025-03-09 09:44:42'),
(202, 'Admin', 'Administrator', 'Login', '2025-03-09 09:51:48'),
(203, 'Admin', 'Administrator', 'Login', '2025-03-09 09:52:21'),
(204, 'Admin', 'Administrator', 'Login', '2025-03-09 09:53:03'),
(205, 'Admin', 'Administrator', 'Login', '2025-03-09 10:00:43'),
(206, 'Admin', 'Administrator', 'Login', '2025-03-09 10:13:40'),
(207, 'Admin', 'Administrator', 'Login', '2025-03-09 10:18:51'),
(208, 'Admin', 'Administrator', 'Login', '2025-03-09 10:22:12'),
(209, 'Admin', 'Administrator', 'Login', '2025-03-09 10:23:32'),
(210, 'Admin', 'Administrator', 'Login', '2025-03-09 10:23:48'),
(211, 'Admin', 'Administrator', 'Login', '2025-03-09 10:49:43'),
(212, 'Admin', 'Administrator', 'Login', '2025-03-09 10:50:42'),
(213, 'Admin', 'Administrator', 'Login', '2025-03-09 10:52:33'),
(214, 'Admin', 'Administrator', 'Login', '2025-03-09 10:53:52'),
(215, 'Admin', 'Administrator', 'Login', '2025-03-09 10:54:41'),
(216, 'Admin', 'Administrator', 'Login', '2025-03-09 10:55:37'),
(217, 'Admin', 'Administrator', 'Login', '2025-03-09 10:56:30'),
(218, 'Admin', 'Administrator', 'Login', '2025-03-09 10:57:15'),
(219, 'Admin', 'Administrator', 'Login', '2025-03-09 10:58:26'),
(220, 'Admin', 'Administrator', 'Login', '2025-03-09 11:02:28'),
(221, 'Cashier', '', 'Login', '2025-03-09 11:05:06'),
(222, 'Admin', 'Administrator', 'Login', '2025-03-09 11:06:41'),
(223, 'Cashier', '', 'Login', '2025-03-09 11:06:54'),
(224, 'Admin', 'Administrator', 'Login', '2025-03-09 11:08:20'),
(225, 'Admin', 'Administrator', 'Login', '2025-03-09 11:14:13'),
(226, 'Admin', 'Administrator', 'Login', '2025-03-09 11:14:35'),
(227, 'Admin', 'Administrator', 'Login', '2025-03-09 11:16:06'),
(228, 'Admin', 'Administrator', 'Login', '2025-03-09 11:18:02'),
(229, 'Admin', 'Administrator', 'Login', '2025-03-09 11:25:20'),
(230, 'Admin', 'Administrator', 'Login', '2025-03-09 11:25:47'),
(231, 'Admin', 'Administrator', 'Login', '2025-03-09 11:27:40'),
(232, 'Admin', 'Administrator', 'Login', '2025-03-09 11:50:04'),
(233, 'Admin', 'Administrator', 'Login', '2025-03-09 11:51:19'),
(234, 'Admin', 'Administrator', 'Login', '2025-03-09 11:51:39'),
(235, 'Admin', 'Administrator', 'Login', '2025-03-09 11:51:58'),
(236, 'Admin', 'Administrator', 'Login', '2025-03-09 11:52:55'),
(237, 'Admin', 'Administrator', 'Login', '2025-03-09 11:53:30'),
(238, 'Admin', 'Administrator', 'Login', '2025-03-09 11:58:08'),
(239, 'Cashier', '', 'Login', '2025-03-09 11:58:23'),
(240, 'Admin', 'Administrator', 'Login', '2025-03-09 12:00:13'),
(241, 'Cashier', '', 'Login', '2025-03-09 12:00:28'),
(242, 'Admin', 'Administrator', 'Login', '2025-03-09 12:04:23'),
(243, 'Admin', 'Administrator', 'Login', '2025-03-09 12:04:36'),
(244, 'Cashier', '', 'Login', '2025-03-09 12:04:49'),
(245, 'Admin', 'Administrator', 'Login', '2025-03-09 12:05:39'),
(246, 'Admin', 'Administrator', 'Login', '2025-03-09 12:12:22'),
(247, 'Admin', 'Administrator', 'Login', '2025-03-09 12:13:25'),
(248, 'Admin', 'Administrator', 'Login', '2025-03-09 12:14:28'),
(249, 'Admin', 'Administrator', 'Login', '2025-03-09 12:14:49'),
(250, 'Admin', 'Administrator', 'Login', '2025-03-09 12:15:28'),
(251, 'Admin', 'Administrator', 'Login', '2025-03-09 12:16:16'),
(252, 'Admin', 'Administrator', 'Login', '2025-03-09 12:16:33'),
(253, 'Admin', 'Administrator', 'Login', '2025-03-09 12:16:57'),
(254, 'Admin', 'Administrator', 'Login', '2025-03-09 12:18:29'),
(255, 'Admin', 'Administrator', 'Login', '2025-03-09 12:24:33'),
(256, 'Admin', 'Administrator', 'Login', '2025-03-09 12:25:13'),
(257, 'Admin', 'Administrator', 'Login', '2025-03-09 12:25:53'),
(258, 'Admin', 'Administrator', 'Login', '2025-03-09 12:26:48'),
(259, 'Admin', 'Administrator', 'Login', '2025-03-09 12:28:29'),
(260, 'Admin', 'Administrator', 'Login', '2025-03-09 12:28:54'),
(261, 'Admin', 'Administrator', 'Login', '2025-03-09 12:29:27'),
(262, 'Admin', 'Administrator', 'Login', '2025-03-09 12:30:16'),
(263, 'Admin', 'Administrator', 'Login', '2025-03-09 12:30:41'),
(264, 'Admin', 'Administrator', 'Login', '2025-03-09 12:31:02'),
(265, 'Admin', 'Administrator', 'Login', '2025-03-09 12:33:50'),
(266, 'Admin', 'Administrator', 'Login', '2025-03-09 12:40:46'),
(267, 'Admin', 'Administrator', 'Login', '2025-03-09 12:43:37'),
(268, 'Admin', 'Administrator', 'Login', '2025-03-09 12:45:59'),
(269, 'Admin', 'Administrator', 'Login', '2025-03-09 12:47:38'),
(270, 'Cashier', '', 'Login', '2025-03-09 12:48:33'),
(271, 'Cashier', '', 'Login', '2025-03-09 12:51:46'),
(272, 'Cashier', '', 'Login', '2025-03-09 13:02:37'),
(273, 'Admin', 'Administrator', 'Login', '2025-03-09 13:09:12'),
(274, 'Admin', 'Administrator', 'Login', '2025-03-09 13:13:55'),
(275, 'Admin', 'Administrator', 'Login', '2025-03-09 13:15:12'),
(276, 'Admin', 'Administrator', 'Login', '2025-03-09 13:15:56'),
(277, 'Admin', 'Administrator', 'Login', '2025-03-09 13:18:00'),
(278, 'Admin', 'Administrator', 'Login', '2025-03-09 13:20:23'),
(279, 'Admin', 'Administrator', 'Login', '2025-03-09 13:20:53'),
(280, 'Admin', 'Administrator', 'Login', '2025-03-09 13:21:46'),
(281, 'Admin', 'Administrator', 'Login', '2025-03-09 13:22:26'),
(282, 'Admin', 'Administrator', 'Login', '2025-03-09 13:22:48'),
(283, 'Admin', 'Administrator', 'Login', '2025-03-09 13:23:58'),
(284, 'Admin', 'Administrator', 'Login', '2025-03-09 13:24:32'),
(285, 'Admin', 'Administrator', 'Login', '2025-03-09 13:25:57'),
(286, 'Admin', 'Administrator', 'Login', '2025-03-09 13:26:45'),
(287, 'Admin', 'Administrator', 'Login', '2025-03-09 13:27:43'),
(288, 'Admin', 'Administrator', 'Login', '2025-03-09 13:30:22'),
(289, 'Admin', 'Administrator', 'Login', '2025-03-09 13:31:29'),
(290, 'Admin', 'Administrator', 'Login', '2025-03-09 13:32:07'),
(291, 'Admin', 'Administrator', 'Login', '2025-03-09 13:33:30'),
(292, 'Admin', 'Administrator', 'Login', '2025-03-09 13:34:01'),
(293, 'Admin', 'Administrator', 'Login', '2025-03-09 13:34:28'),
(294, 'Admin', 'Administrator', 'Login', '2025-03-09 13:46:25'),
(295, 'Admin', 'Administrator', 'Login', '2025-03-09 13:47:20'),
(296, 'Admin', 'Administrator', 'Login', '2025-03-09 13:59:01'),
(297, 'Admin', 'Administrator', 'Login', '2025-03-09 14:02:27'),
(298, 'Admin', 'Administrator', 'Login', '2025-03-09 15:17:09'),
(299, 'Admin', 'Administrator', 'Login', '2025-03-09 15:24:42'),
(300, 'Admin', 'Administrator', 'Login', '2025-03-09 15:28:50'),
(301, 'Admin', 'Administrator', 'Login', '2025-03-09 15:31:12'),
(302, 'Admin', 'Administrator', 'Login', '2025-03-09 15:33:52'),
(303, 'Admin', 'Administrator', 'Login', '2025-03-09 15:42:10'),
(304, 'Admin', 'Administrator', 'Login', '2025-03-09 15:48:10'),
(305, 'Admin', 'Administrator', 'Login', '2025-03-09 15:49:21'),
(306, 'Admin', 'Administrator', 'Login', '2025-03-09 15:50:40'),
(307, 'Admin', 'Administrator', 'Login', '2025-03-09 15:53:02'),
(308, 'Admin', 'Administrator', 'Login', '2025-03-09 16:06:45'),
(309, 'Admin', 'Administrator', 'Login', '2025-03-09 16:12:28'),
(310, 'Admin', 'Administrator', 'Login', '2025-03-09 16:17:33'),
(311, 'Admin', 'Administrator', 'Login', '2025-03-09 16:28:37'),
(312, 'Admin', 'Administrator', 'Login', '2025-03-09 16:35:58'),
(313, 'Admin', 'Administrator', 'Login', '2025-03-09 16:43:25'),
(314, 'Admin', 'Administrator', 'Login', '2025-03-09 16:51:13'),
(315, 'Admin', 'Administrator', 'Login', '2025-03-09 16:53:45'),
(316, 'Admin', 'Administrator', 'Login', '2025-03-09 16:55:31'),
(317, 'Admin', 'Administrator', 'Login', '2025-03-09 16:56:22'),
(318, 'Admin', 'Administrator', 'Login', '2025-03-09 16:56:55'),
(319, 'Admin', 'Administrator', 'Login', '2025-03-09 17:02:20'),
(320, 'Admin', 'Administrator', 'Login', '2025-03-09 17:10:53'),
(321, 'Admin', 'Administrator', 'Login', '2025-03-09 17:12:18'),
(322, 'Admin', 'Administrator', 'Login', '2025-03-09 17:13:16'),
(323, 'Admin', 'Administrator', 'Login', '2025-03-09 17:21:40'),
(324, 'Admin', 'Administrator', 'Login', '2025-03-09 17:26:49'),
(325, 'Admin', 'Administrator', 'Login', '2025-03-09 17:27:06'),
(326, 'Admin', 'Administrator', 'Login', '2025-03-09 17:27:41'),
(327, 'Admin', 'Administrator', 'Login', '2025-03-09 17:33:07'),
(328, 'Admin', 'Administrator', 'Login', '2025-03-09 17:35:29'),
(329, 'Admin', 'Administrator', 'Login', '2025-03-09 17:36:52'),
(330, 'Admin', 'Administrator', 'Login', '2025-03-09 17:37:41'),
(331, 'Admin', 'Administrator', 'Login', '2025-03-09 17:39:16'),
(332, 'Admin', 'Administrator', 'Login', '2025-03-09 17:41:59'),
(333, 'Admin', 'Administrator', 'Login', '2025-03-09 17:49:50'),
(334, 'Admin', 'Administrator', 'Login', '2025-03-09 17:51:08'),
(335, 'Admin', 'Administrator', 'Login', '2025-03-09 17:52:38'),
(336, 'Admin', 'Administrator', 'Login', '2025-03-09 23:16:47'),
(337, 'Admin', 'Administrator', 'Login', '2025-03-09 23:19:24'),
(338, 'Admin', 'Administrator', 'Login', '2025-03-09 23:20:50'),
(339, 'Admin', 'Administrator', 'Login', '2025-03-09 23:22:04'),
(340, 'Admin', 'Administrator', 'Login', '2025-03-09 23:51:25'),
(341, 'Admin', 'Administrator', 'Login', '2025-03-09 23:54:11'),
(342, 'Admin', 'Administrator', 'Login', '2025-03-10 00:03:06'),
(343, 'Admin', 'Administrator', 'Login', '2025-03-10 00:03:49'),
(344, 'Admin', 'Administrator', 'Login', '2025-03-10 00:10:49'),
(345, 'Admin', 'Administrator', 'Login', '2025-03-10 00:12:58'),
(346, 'Admin', 'Administrator', 'Login', '2025-03-10 00:17:52'),
(347, 'Admin', 'Administrator', 'Login', '2025-03-10 00:21:02'),
(348, 'Admin', 'Administrator', 'Login', '2025-03-10 00:22:19'),
(349, 'Admin', 'Administrator', 'Login', '2025-03-10 00:25:02'),
(350, 'Admin', 'Administrator', 'Login', '2025-03-10 00:30:13'),
(351, 'Admin', 'Administrator', 'Login', '2025-03-10 00:53:57'),
(352, 'Admin', 'Administrator', 'Login', '2025-03-10 00:56:10'),
(353, 'Admin', 'Administrator', 'Login', '2025-03-10 00:57:17'),
(354, 'Admin', 'Administrator', 'Login', '2025-03-10 00:59:03'),
(355, 'Admin', 'Administrator', 'Login', '2025-03-10 00:59:40'),
(356, 'Admin', 'Administrator', 'Login', '2025-03-10 01:00:53'),
(357, 'Admin', 'Administrator', 'Login', '2025-03-10 01:08:07'),
(358, 'Admin', 'Administrator', 'Login', '2025-03-10 01:13:53'),
(359, 'Admin', 'Administrator', 'Login', '2025-03-10 01:14:29'),
(360, 'Admin', 'Administrator', 'Login', '2025-03-10 01:19:19'),
(361, 'Admin', 'Administrator', 'Login', '2025-03-10 01:30:57'),
(362, 'Admin', 'Administrator', 'Login', '2025-03-10 01:31:57'),
(363, 'Admin', 'Administrator', 'Login', '2025-03-10 01:36:43'),
(364, 'Admin', 'Administrator', 'Login', '2025-03-10 10:37:57'),
(365, 'Admin', 'Administrator', 'Login', '2025-03-10 10:45:32'),
(366, 'Admin', 'Administrator', 'Login', '2025-03-10 10:55:58'),
(367, 'Admin', 'Administrator', 'Login', '2025-03-10 11:03:01'),
(368, 'Admin', 'Administrator', 'Login', '2025-03-10 11:04:28'),
(369, 'Admin', 'Administrator', 'Login', '2025-03-10 11:06:50'),
(370, 'Admin', 'Administrator', 'Login', '2025-03-10 11:08:48'),
(371, 'Admin', 'Administrator', 'Login', '2025-03-10 11:17:16'),
(372, 'Admin', 'Administrator', 'Login', '2025-03-10 11:22:02'),
(373, 'Admin', 'Administrator', 'Login', '2025-03-10 11:25:34'),
(374, 'Admin', 'Administrator', 'Login', '2025-03-10 11:29:56'),
(375, 'Admin', 'Administrator', 'Login', '2025-03-10 11:39:14'),
(376, 'Admin', 'Administrator', 'Login', '2025-03-10 11:44:59'),
(377, 'Admin', 'Administrator', 'Login', '2025-03-10 11:52:56'),
(378, 'Admin', 'Administrator', 'Login', '2025-03-10 11:53:49'),
(379, 'Admin', 'Administrator', 'Login', '2025-03-10 11:58:46'),
(380, 'Admin', 'Administrator', 'Login', '2025-03-10 12:40:22'),
(381, 'Admin', 'Administrator', 'Login', '2025-03-10 12:42:33'),
(382, 'Admin', 'Administrator', 'Login', '2025-03-10 12:45:50'),
(383, 'Admin', 'Administrator', 'Login', '2025-03-10 12:46:42'),
(384, 'Admin', 'Administrator', 'Login', '2025-03-10 12:52:46'),
(385, 'Admin', 'Administrator', 'Login', '2025-03-10 12:56:15'),
(386, 'Admin', 'Administrator', 'Login', '2025-03-10 13:04:09'),
(387, 'Admin', 'Administrator', 'Login', '2025-03-10 13:07:07'),
(388, 'Admin', 'Administrator', 'Login', '2025-03-10 13:10:28'),
(389, 'Admin', 'Administrator', 'Login', '2025-03-10 13:14:07'),
(390, 'Admin', 'Administrator', 'Login', '2025-03-10 13:16:01'),
(391, 'Admin', 'Administrator', 'Login', '2025-03-10 13:16:25'),
(392, 'Admin', 'Administrator', 'Login', '2025-03-10 13:18:26'),
(393, 'Admin', 'Administrator', 'Login', '2025-03-10 13:20:02'),
(394, 'Admin', 'Administrator', 'Login', '2025-03-10 13:20:38'),
(395, 'Admin', 'Administrator', 'Login', '2025-03-10 13:21:27'),
(396, 'Admin', 'Administrator', 'Login', '2025-03-10 13:29:41'),
(397, 'Admin', 'Administrator', 'Login', '2025-03-10 13:37:17'),
(398, 'Admin', 'Administrator', 'Login', '2025-03-10 13:39:44'),
(399, 'Admin', 'Administrator', 'Login', '2025-03-10 13:44:41'),
(400, 'Admin', 'Administrator', 'Login', '2025-03-10 13:45:54'),
(401, 'Admin', 'Administrator', 'Login', '2025-03-10 13:47:30'),
(402, 'Admin', 'Administrator', 'Login', '2025-03-10 13:52:03'),
(403, 'Admin', 'Administrator', 'Login', '2025-03-10 13:54:18'),
(404, 'Admin', 'Administrator', 'Login', '2025-03-10 14:11:27'),
(405, 'Admin', 'Administrator', 'Login', '2025-03-10 14:16:06'),
(406, 'Admin', 'Administrator', 'Login', '2025-03-10 14:17:55'),
(407, 'Admin', 'Administrator', 'Login', '2025-03-10 14:20:22'),
(408, 'Admin', 'Administrator', 'Login', '2025-03-10 14:21:25'),
(409, 'Admin', 'Administrator', 'Login', '2025-03-10 14:23:56'),
(410, 'Admin', 'Administrator', 'Login', '2025-03-10 14:25:02'),
(411, 'Admin', 'Administrator', 'Login', '2025-03-10 14:27:19'),
(412, 'Admin', 'Administrator', 'Login', '2025-03-10 14:34:42'),
(413, 'Admin', 'Administrator', 'Login', '2025-03-10 14:39:46'),
(414, 'Admin', 'Administrator', 'Login', '2025-03-10 14:43:58'),
(415, 'Admin', 'Administrator', 'Login', '2025-03-10 14:46:54'),
(416, 'Admin', 'Administrator', 'Login', '2025-03-10 22:26:41'),
(417, 'Admin', 'Administrator', 'Login', '2025-03-10 22:29:59'),
(418, 'Admin', 'Administrator', 'Login', '2025-03-10 22:32:10'),
(419, 'Admin', 'Administrator', 'Login', '2025-03-10 22:34:00'),
(420, 'Admin', 'Administrator', 'Login', '2025-03-10 22:35:12'),
(421, 'Admin', 'Administrator', 'Login', '2025-03-10 22:39:54'),
(422, 'Admin', 'Administrator', 'Login', '2025-03-10 22:42:53'),
(423, 'Admin', 'Administrator', 'Login', '2025-03-10 22:48:34'),
(424, 'Admin', 'Administrator', 'Login', '2025-03-11 02:14:06'),
(425, 'Admin', 'Administrator', 'Login', '2025-03-11 02:19:28'),
(426, 'Admin', 'Administrator', 'Login', '2025-03-11 02:21:07'),
(427, 'Admin', 'Administrator', 'Login', '2025-03-11 02:22:38'),
(428, 'Admin', 'Administrator', 'Login', '2025-03-11 02:24:04'),
(429, 'Admin', 'Administrator', 'Login', '2025-03-11 02:29:09'),
(430, 'Admin', 'Administrator', 'Login', '2025-03-11 02:30:16'),
(431, 'Admin', 'Administrator', 'Login', '2025-03-11 02:32:05'),
(432, 'Admin', 'Administrator', 'Login', '2025-03-11 02:32:45'),
(433, 'Admin', 'Administrator', 'Login', '2025-03-11 02:36:37'),
(434, 'Admin', 'Administrator', 'Login', '2025-03-11 02:37:19'),
(435, 'Admin', 'Administrator', 'Login', '2025-03-11 02:38:49'),
(436, 'Admin', 'Administrator', 'Login', '2025-03-11 02:39:45'),
(437, 'Admin', 'Administrator', 'Login', '2025-03-11 02:40:29'),
(438, 'Admin', 'Administrator', 'Login', '2025-03-11 02:42:27'),
(439, 'Admin', 'Administrator', 'Login', '2025-03-11 02:42:59'),
(440, 'Admin', 'Administrator', 'Login', '2025-03-11 02:45:00'),
(441, 'Admin', 'Administrator', 'Login', '2025-03-11 02:45:33'),
(442, 'Admin', 'Administrator', 'Login', '2025-03-11 02:46:07'),
(443, 'Admin', 'Administrator', 'Login', '2025-03-11 02:46:49'),
(444, 'Admin', 'Administrator', 'Login', '2025-03-11 02:47:19'),
(445, 'Admin', 'Administrator', 'Login', '2025-03-11 02:50:14'),
(446, 'Admin', 'Administrator', 'Login', '2025-03-11 02:50:59'),
(447, 'Admin', 'Administrator', 'Login', '2025-03-11 02:52:35'),
(448, 'Admin', 'Administrator', 'Login', '2025-03-11 02:53:52'),
(449, 'Admin', 'Administrator', 'Login', '2025-03-11 02:57:38'),
(450, 'Admin', 'Administrator', 'Login', '2025-03-11 02:57:51'),
(451, 'Admin', 'Administrator', 'Login', '2025-03-11 02:58:22'),
(452, 'Admin', 'Administrator', 'Login', '2025-03-11 02:59:02'),
(453, 'Admin', 'Administrator', 'Login', '2025-03-11 02:59:27'),
(454, 'Admin', 'Administrator', 'Login', '2025-03-11 03:01:12'),
(455, 'Admin', 'Administrator', 'Login', '2025-03-11 03:02:39'),
(456, 'Admin', 'Administrator', 'Login', '2025-03-11 03:05:36'),
(457, 'Admin', 'Administrator', 'Login', '2025-03-11 03:06:59'),
(458, 'Admin', 'Administrator', 'Login', '2025-03-11 03:24:24'),
(459, 'Admin', 'Administrator', 'Login', '2025-03-11 03:25:38'),
(460, 'Admin', 'Administrator', 'Login', '2025-03-11 03:27:48'),
(461, 'Admin', 'Administrator', 'Login', '2025-03-11 03:33:43'),
(462, 'Admin', 'Administrator', 'Login', '2025-03-11 03:35:55'),
(463, 'Admin', 'Administrator', 'Login', '2025-03-11 03:36:33'),
(464, 'Admin', 'Administrator', 'Login', '2025-03-11 03:37:20'),
(465, 'Admin', 'Administrator', 'Login', '2025-03-11 03:38:14'),
(466, 'Admin', 'Administrator', 'Login', '2025-03-11 03:38:55'),
(467, 'Admin', 'Administrator', 'Login', '2025-03-11 03:42:25'),
(468, 'Admin', 'Administrator', 'Login', '2025-03-11 03:43:10'),
(469, 'Admin', 'Administrator', 'Login', '2025-03-11 04:05:26'),
(470, 'Admin', 'Administrator', 'Login', '2025-03-11 04:06:39'),
(471, 'Admin', 'Administrator', 'Login', '2025-03-11 04:13:31'),
(472, 'Admin', 'Administrator', 'Login', '2025-03-11 04:15:10'),
(473, 'Admin', 'Administrator', 'Login', '2025-03-11 04:18:14'),
(474, 'Admin', 'Administrator', 'Login', '2025-03-11 04:18:54'),
(475, 'Admin', 'Administrator', 'Login', '2025-03-11 04:20:34'),
(476, 'Admin', 'Administrator', 'Login', '2025-03-11 04:26:21'),
(477, 'Admin', 'Administrator', 'Login', '2025-03-11 04:34:21'),
(478, 'Admin', 'Administrator', 'Login', '2025-03-11 04:36:12'),
(479, 'Admin', 'Administrator', 'Login', '2025-03-11 04:38:09'),
(480, 'Admin', 'Administrator', 'Login', '2025-03-11 04:39:32'),
(481, 'Admin', 'Administrator', 'Login', '2025-03-11 04:42:20'),
(482, 'Admin', 'Administrator', 'Login', '2025-03-11 04:42:39'),
(483, 'Admin', 'Administrator', 'Login', '2025-03-11 04:44:41'),
(484, 'Admin', 'Administrator', 'Login', '2025-03-11 04:46:01'),
(485, 'Admin', 'Administrator', 'Login', '2025-03-11 04:48:13'),
(486, 'Admin', 'Administrator', 'Login', '2025-03-11 04:51:00'),
(487, 'Admin', 'Administrator', 'Login', '2025-03-11 04:53:28'),
(488, 'Admin', 'Administrator', 'Login', '2025-03-11 04:54:37'),
(489, 'Admin', 'Administrator', 'Login', '2025-03-11 04:58:41'),
(490, 'Admin', 'Administrator', 'Login', '2025-03-11 04:59:25'),
(491, 'Admin', 'Administrator', 'Login', '2025-03-11 05:08:51'),
(492, 'Admin', 'Administrator', 'Login', '2025-03-11 05:10:43'),
(493, 'Admin', 'Administrator', 'Login', '2025-03-11 05:16:27'),
(494, 'Admin', 'Administrator', 'Login', '2025-03-11 05:16:54'),
(495, 'Admin', 'Administrator', 'Login', '2025-03-11 05:21:46'),
(496, 'Admin', 'Administrator', 'Login', '2025-03-11 05:25:58'),
(497, 'Admin', 'Administrator', 'Login', '2025-03-11 05:29:13'),
(498, 'Admin', 'Administrator', 'Login', '2025-03-11 05:30:40'),
(499, 'Admin', 'Administrator', 'Login', '2025-03-11 05:31:12'),
(500, 'Admin', 'Administrator', 'Login', '2025-03-11 05:32:50'),
(501, 'Admin', 'Administrator', 'Login', '2025-03-11 05:37:52'),
(502, 'Admin', 'Administrator', 'Login', '2025-03-11 05:39:09'),
(503, 'Admin', 'Administrator', 'Login', '2025-03-11 05:39:53'),
(504, 'Admin', 'Administrator', 'Login', '2025-03-11 05:59:00'),
(505, 'Admin', 'Administrator', 'Login', '2025-03-11 06:19:24'),
(506, 'Admin', 'Administrator', 'Login', '2025-03-11 06:20:31'),
(507, 'Admin', 'Administrator', 'Login', '2025-03-11 06:21:02'),
(508, 'Admin', 'Administrator', 'Login', '2025-03-11 06:31:25'),
(509, 'Admin', 'Administrator', 'Login', '2025-03-11 06:34:42'),
(510, 'Admin', 'Administrator', 'Login', '2025-03-11 06:37:23'),
(511, 'Admin', 'Administrator', 'Login', '2025-03-11 06:38:55'),
(512, 'Admin', 'Administrator', 'Login', '2025-03-11 11:39:35'),
(513, 'Admin', 'Administrator', 'Login', '2025-03-11 12:01:38'),
(514, 'Admin', 'Administrator', 'Login', '2025-03-11 12:04:16'),
(515, 'Admin', 'Administrator', 'Login', '2025-03-11 12:08:22'),
(516, 'Admin', 'Administrator', 'Login', '2025-03-11 12:09:08'),
(517, 'Admin', 'Administrator', 'Login', '2025-03-11 12:11:46'),
(518, 'Admin', 'Administrator', 'Login', '2025-03-11 12:14:33'),
(519, 'Admin', 'Administrator', 'Login', '2025-03-11 12:15:55'),
(520, 'Admin', 'Administrator', 'Login', '2025-03-11 12:24:49'),
(521, 'Admin', 'Administrator', 'Login', '2025-03-11 12:27:56'),
(522, 'Admin', 'Administrator', 'Login', '2025-03-11 12:33:19'),
(523, 'Admin', 'Administrator', 'Login', '2025-03-11 12:42:50'),
(524, 'Admin', 'Administrator', 'Login', '2025-03-11 12:44:57'),
(525, 'Admin', 'Administrator', 'Login', '2025-03-11 12:45:37'),
(526, 'Admin', 'Administrator', 'Login', '2025-03-11 12:48:36'),
(527, 'Admin', 'Administrator', 'Login', '2025-03-11 12:51:56'),
(528, 'Admin', 'Administrator', 'Login', '2025-03-11 12:59:50'),
(529, 'Admin', 'Administrator', 'Login', '2025-03-11 13:02:50'),
(530, 'Admin', 'Administrator', 'Login', '2025-03-11 13:06:41'),
(531, 'Admin', 'Administrator', 'Login', '2025-03-11 13:59:36'),
(532, 'Admin', 'Administrator', 'Login', '2025-03-11 14:22:54'),
(533, 'Admin', 'Administrator', 'Login', '2025-03-11 14:31:02'),
(534, 'Admin', 'Administrator', 'Login', '2025-03-11 14:33:49'),
(535, 'Admin', 'Administrator', 'Login', '2025-03-11 14:35:22'),
(536, 'Admin', 'Administrator', 'Login', '2025-03-11 14:37:21'),
(537, 'Admin', 'Administrator', 'Login', '2025-03-11 14:37:51'),
(538, 'Admin', 'Administrator', 'Login', '2025-03-11 14:40:39'),
(539, 'Admin', 'Administrator', 'Login', '2025-03-11 14:42:38'),
(540, 'Admin', 'Administrator', 'Login', '2025-03-11 14:46:29'),
(541, 'Admin', 'Administrator', 'Login', '2025-03-11 14:49:44'),
(542, 'Admin', 'Administrator', 'Login', '2025-03-11 14:53:12'),
(543, 'Admin', 'Administrator', 'Login', '2025-03-11 15:08:24'),
(544, 'Admin', 'Administrator', 'Login', '2025-03-11 15:10:22'),
(545, 'Admin', 'Administrator', 'Login', '2025-03-11 18:27:12'),
(546, 'Admin', 'Administrator', 'Login', '2025-03-19 01:45:57'),
(547, 'Admin', 'Administrator', 'Login', '2025-03-19 01:53:07'),
(548, 'Admin', 'Administrator', 'Login', '2025-03-19 01:55:51'),
(549, 'Admin', 'Administrator', 'Login', '2025-03-19 02:01:04'),
(550, 'Admin', 'Administrator', 'Login', '2025-03-19 02:01:49'),
(551, 'Admin', 'Administrator', 'Login', '2025-03-19 02:04:22'),
(552, 'Admin', 'Administrator', 'Login', '2025-03-19 02:05:36'),
(553, 'Admin', 'Administrator', 'Login', '2025-03-19 02:15:31'),
(554, 'Admin', 'Administrator', 'Login', '2025-03-19 02:16:55'),
(555, 'Admin', 'Administrator', 'Login', '2025-03-19 02:17:21'),
(556, 'Admin', 'Administrator', 'Login', '2025-03-19 02:17:47'),
(557, 'Admin', 'Administrator', 'Login', '2025-03-19 02:18:32'),
(558, 'Admin', 'Administrator', 'Login', '2025-03-19 14:46:03'),
(559, 'Admin', 'Administrator', 'Login', '2025-03-19 14:47:04'),
(560, 'Admin', 'Administrator', 'Login', '2025-03-19 15:22:58'),
(561, 'Admin', 'Administrator', 'Login', '2025-03-19 15:24:02'),
(562, 'Cashier', 'oreo boy J visperas', 'Login', '2025-03-19 15:24:30'),
(563, 'Admin', 'Administrator', 'Login', '2025-03-19 19:19:27'),
(564, 'Admin', 'Administrator', 'Login', '2025-03-19 19:20:45'),
(565, 'Cashier', 'cashierrrrr c cashierrrrr', 'Login', '2025-03-19 19:22:07'),
(566, 'Admin', 'Administrator', 'Login', '2025-03-19 19:22:32'),
(567, 'Admin', 'Administrator', 'Login', '2025-03-19 19:24:27'),
(568, 'Cashier', 'cashierrrrr c cashierrrrr', 'Login', '2025-03-19 19:25:22'),
(569, 'Cashier', 'cashierrrrr c cashierrrrr', 'Login', '2025-03-19 19:33:44'),
(570, 'Admin', 'Administrator', 'Login', '2025-03-19 19:35:31'),
(571, 'Cashier', 'cashierrrrr c cashierrrrr', 'Login', '2025-03-19 19:38:09'),
(572, 'Cashier', 'cashierrrrr c cashierrrrr', 'Login', '2025-03-19 19:38:42'),
(573, 'Cashier', 'cashierrrrr c cashierrrrr', 'Login', '2025-03-19 19:39:13'),
(574, 'Admin', 'Administrator', 'Login', '2025-03-19 19:46:04'),
(575, 'Admin', 'Administrator', 'Login', '2025-03-19 19:47:17'),
(576, 'Admin', 'Administrator', 'Login', '2025-03-19 20:00:31'),
(577, 'Admin', 'Administrator', 'Login', '2025-03-19 20:02:28'),
(578, 'Admin', 'Administrator', 'Login', '2025-03-19 20:05:01'),
(579, 'Admin', 'Administrator', 'Login', '2025-03-19 20:13:51'),
(580, 'Admin', 'Administrator', 'Login', '2025-03-19 20:21:08'),
(581, 'Admin', 'Administrator', 'Login', '2025-03-19 20:32:05'),
(582, 'Admin', 'Administrator', 'Login', '2025-03-19 20:33:00'),
(583, 'Admin', 'Administrator', 'Login', '2025-03-19 20:35:59'),
(584, 'Admin', 'Administrator', 'Login', '2025-03-19 20:36:49'),
(585, 'Admin', 'Administrator', 'Login', '2025-03-19 20:38:42'),
(586, 'Admin', 'Administrator', 'Login', '2025-03-19 21:31:03'),
(587, 'Cashier', 'joshua a arm', 'Login', '2025-03-19 21:35:33'),
(588, 'Cashier', 'joshua a arm', 'Login', '2025-03-19 21:47:23'),
(589, 'Cashier', 'joshua a arm', 'Login', '2025-03-19 22:57:36'),
(590, 'Admin', 'Administrator', 'Login', '2025-03-19 23:21:36'),
(591, 'Admin', 'Administrator', 'Login', '2025-03-19 23:24:57'),
(592, 'Admin', 'Administrator', 'Login', '2025-03-19 23:46:11'),
(593, 'Admin', 'Administrator', 'Login', '2025-03-19 23:53:35'),
(594, 'Admin', 'Administrator', 'Login', '2025-03-19 23:54:16'),
(595, 'Admin', 'Administrator', 'Login', '2025-03-20 00:00:39'),
(596, 'Admin', 'Administrator', 'Login', '2025-03-20 00:19:19'),
(597, 'Admin', 'Administrator', 'Login', '2025-03-20 00:42:08'),
(598, 'Admin', 'Administrator', 'Login', '2025-03-20 00:44:27'),
(599, 'Admin', 'Administrator', 'Login', '2025-03-20 00:47:01'),
(600, 'Admin', 'Administrator', 'Login', '2025-03-20 00:51:50'),
(601, 'Admin', 'Administrator', 'Login', '2025-03-20 00:53:10'),
(602, 'Admin', 'Administrator', 'Login', '2025-03-20 00:55:38'),
(603, 'Admin', 'Administrator', 'Login', '2025-03-20 01:04:37'),
(604, 'Admin', 'Administrator', 'Login', '2025-03-20 01:08:37'),
(605, 'Admin', 'Administrator', 'Login', '2025-03-20 01:09:53'),
(606, 'Admin', 'Administrator', 'Login', '2025-03-20 20:53:49'),
(607, 'Cashier', 'joshua a arm', 'Login', '2025-03-20 21:07:07'),
(608, 'Admin', 'Administrator', 'Login', '2025-03-20 21:08:14'),
(609, 'Staff', 'cj ja jc', 'Login', '2025-03-22 13:51:56'),
(610, 'Admin', 'Administrator', 'Login', '2025-03-22 13:54:19'),
(611, 'Admin', 'Administrator', 'Login', '2025-03-22 14:04:35'),
(612, 'Cashier', 'joshua a arm', 'Login', '2025-03-22 14:13:07'),
(613, 'Admin', 'Administrator', 'Login', '2025-03-22 14:24:10');

-- --------------------------------------------------------

--
-- Table structure for table `products`
--

CREATE TABLE `products` (
  `product_id` int NOT NULL,
  `product_name` varchar(100) COLLATE utf8mb4_general_ci NOT NULL,
  `barcode` varchar(50) COLLATE utf8mb4_general_ci NOT NULL,
  `description` text COLLATE utf8mb4_general_ci,
  `selling_price` decimal(10,2) NOT NULL,
  `cost_price` decimal(10,2) NOT NULL,
  `category_id` int DEFAULT NULL,
  `created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `expiration_option` varchar(50) COLLATE utf8mb4_general_ci NOT NULL,
  `expiration_date` date DEFAULT NULL,
  `stock` int DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `products`
--

INSERT INTO `products` (`product_id`, `product_name`, `barcode`, `description`, `selling_price`, `cost_price`, `category_id`, `created_at`, `updated_at`, `expiration_option`, `expiration_date`, `stock`) VALUES
(45, 'Milo', '123321123', 'qwe', '12.00', '15.00', 10, '2025-03-10 04:29:05', '2025-03-10 04:29:05', 'With Expiration', NULL, 0),
(46, 'Milo', '0909', 'qwe', '12.00', '15.00', 10, '2025-03-10 04:53:00', '2025-03-10 04:53:00', 'With Expiration', NULL, 0),
(47, 'OREONINA', '24', 'qwe', '12.00', '15.00', 10, '2025-03-10 05:04:41', '2025-03-10 05:04:41', 'With Expiration', NULL, 0),
(48, 'ninako', '2004', 'qwe', '12.00', '15.00', 10, '2025-03-10 05:15:04', '2025-03-10 05:15:04', 'With Expiration', NULL, 0);

-- --------------------------------------------------------

--
-- Table structure for table `sales`
--

CREATE TABLE `sales` (
  `sale_id` int NOT NULL,
  `transaction_number` varchar(50) COLLATE utf8mb4_general_ci NOT NULL,
  `sale_date` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `cashier_id` int NOT NULL,
  `total_amount` decimal(10,2) NOT NULL,
  `discount_amount` decimal(10,2) DEFAULT '0.00',
  `vat_amount` decimal(10,2) DEFAULT '0.00',
  `net_amount` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `sales`
--

INSERT INTO `sales` (`sale_id`, `transaction_number`, `sale_date`, `cashier_id`, `total_amount`, `discount_amount`, `vat_amount`, `net_amount`) VALUES
(102, 'TXN-20241206214435', '2024-12-06 13:44:55', 8, '12.00', '0.00', '0.00', '12.00'),
(103, 'TXN-20241207071013', '2024-12-06 23:10:24', 8, '12.00', '0.00', '0.00', '12.00'),
(104, 'TXN-20241207071525', '2024-12-06 23:15:35', 8, '12.00', '0.00', '0.00', '12.00'),
(105, 'TXN-20241207084303', '2024-12-07 00:46:05', 8, '458.64', '45.50', '49.14', '458.64'),
(106, 'TXN-20241207084659', '2024-12-07 00:47:15', 8, '252.00', '25.00', '27.00', '252.00'),
(107, 'TXN-20241207084728', '2024-12-07 00:47:38', 8, '151.20', '15.00', '16.20', '151.20'),
(108, 'TXN-20241207084752', '2024-12-07 00:48:02', 8, '100.80', '10.00', '10.80', '100.80'),
(109, 'TXN-20241207085002', '2024-12-07 00:50:31', 8, '504.00', '50.00', '54.00', '504.00'),
(110, 'TXN-20241207085157', '2024-12-07 00:52:14', 8, '151.20', '15.00', '16.20', '151.20'),
(111, 'TXN-20241220141724', '2024-12-20 06:17:32', 8, '151.20', '15.00', '16.20', '151.20'),
(112, 'TXN-20241220144021', '2024-12-20 06:40:31', 8, '151.20', '15.00', '16.20', '151.20'),
(113, 'TXN-20241220180800', '2024-12-20 10:08:10', 8, '302.40', '30.00', '32.40', '302.40'),
(114, 'TXN-20250225151857', '2025-02-25 07:19:49', 8, '352.80', '35.00', '37.80', '352.80'),
(115, 'TXN-20250227190341', '2025-02-27 11:04:07', 8, '100.80', '10.00', '10.80', '100.80'),
(116, 'TXN-20250227193438', '2025-02-27 11:34:58', 8, '100.80', '10.00', '10.80', '100.80'),
(117, 'TXN-20250227193525', '2025-02-27 11:35:57', 8, '50.40', '5.00', '5.40', '50.40'),
(118, 'TXN-20250227205000', '2025-02-27 12:50:25', 8, '115.92', '11.50', '12.42', '115.92'),
(119, 'TXN-20250228012109', '2025-02-27 17:21:51', 8, '50.40', '5.00', '5.40', '50.40'),
(120, 'TXN-20250228012155', '2025-02-27 17:22:11', 8, '50.40', '5.00', '5.40', '50.40'),
(121, 'TXN-20250228104735', '2025-02-28 02:47:47', 8, '50.40', '5.00', '5.40', '50.40'),
(122, 'TXN-20250228115444', '2025-02-28 03:56:23', 8, '50.40', '5.00', '5.40', '50.40'),
(123, 'TXN-20250228123915', '2025-02-28 04:42:08', 8, '756.00', '75.00', '81.00', '756.00'),
(124, 'TXN-20250228124837', '2025-02-28 04:50:12', 8, '151.20', '15.00', '16.20', '151.20'),
(125, 'TXN-20250228134431', '2025-02-28 05:45:34', 8, '100.80', '10.00', '10.80', '100.80'),
(126, 'TXN-20250228165540', '2025-02-28 08:57:54', 8, '50.40', '5.00', '5.40', '50.40'),
(127, 'TXN-20250301072913', '2025-02-28 23:32:22', 8, '151.20', '15.00', '16.20', '151.20'),
(128, 'TXN-20250301073230', '2025-02-28 23:39:58', 8, '149.18', '14.80', '15.98', '149.18'),
(129, 'TXN-20250301195404', '2025-03-01 11:56:13', 8, '201.60', '20.00', '21.60', '201.60'),
(130, 'TXN-20250302192436', '2025-03-02 11:24:48', 8, '100.80', '10.00', '10.80', '100.80'),
(131, 'TXN-20250302192818', '2025-03-02 11:29:18', 8, '50.40', '5.00', '5.40', '50.40'),
(132, 'TXN-20250302193302', '2025-03-02 11:33:35', 8, '115.92', '11.50', '12.42', '115.92'),
(133, 'TXN-20250303164950', '2025-03-03 08:50:00', 8, '50.40', '5.00', '5.40', '50.40'),
(134, 'TXN-20250303165041', '2025-03-03 08:50:52', 8, '151.20', '15.00', '16.20', '151.20'),
(135, 'TXN-20250303171154', '2025-03-03 09:12:11', 8, '0.00', '0.00', '0.00', '0.00'),
(136, 'TXN-20250303172052', '2025-03-03 09:22:08', 8, '100.80', '10.00', '10.80', '100.80'),
(137, 'TXN-20250303174047', '2025-03-03 09:41:06', 8, '50.40', '5.00', '5.40', '50.40'),
(138, 'TXN-20250303174109', '2025-03-03 09:41:18', 8, '0.00', '0.00', '0.00', '0.00'),
(158, 'TXN-20250304072450', '2025-03-03 23:24:59', 8, '100.80', '10.00', '10.80', '100.80'),
(159, 'TXN-20250304140413', '2025-03-04 06:07:13', 8, '201.60', '20.00', '21.60', '201.60'),
(160, 'TXN-20250305203556', '2025-03-05 12:36:11', 8, '201.60', '20.00', '21.60', '201.60'),
(161, 'TXN-20250305204249', '2025-03-05 12:44:02', 8, '100.80', '10.00', '10.80', '100.80'),
(162, 'TXN-20250305210516', '2025-03-05 13:05:27', 8, '302.40', '30.00', '32.40', '302.40'),
(163, 'TXN-20250305235028', '2025-03-05 15:51:00', 8, '50.40', '5.00', '5.40', '50.40'),
(164, 'TXN-20250306002936', '2025-03-05 16:29:44', 8, '100.80', '10.00', '10.80', '100.80'),
(168, 'TXN-20250306031407', '2025-03-05 19:14:17', 8, '50.40', '5.00', '5.40', '50.40'),
(169, 'TXN-20250306092312', '2025-03-06 01:23:23', 8, '50.40', '5.00', '5.40', '50.40'),
(170, 'TXN-20250306102357', '2025-03-06 02:25:00', 8, '50.40', '5.00', '5.40', '50.40'),
(171, 'TXN-20250306110331', '2025-03-06 03:03:43', 8, '50.40', '5.00', '5.40', '50.40'),
(172, 'TXN-20250306110922', '2025-03-06 03:09:29', 8, '50.40', '5.00', '5.40', '50.40'),
(173, 'TXN-20250306111930', '2025-03-06 03:19:42', 8, '50.40', '5.00', '5.40', '50.40'),
(174, 'TXN-20250306112223', '2025-03-06 03:23:28', 8, '100.80', '10.00', '10.80', '100.80'),
(175, 'TXN-20250306133252', '2025-03-06 05:33:02', 8, '50.40', '5.00', '5.40', '50.40'),
(176, 'TXN-20250306142141', '2025-03-06 06:21:54', 8, '151.20', '15.00', '16.20', '151.20'),
(177, 'TXN-20250306151142', '2025-03-06 07:11:56', 8, '50.40', '5.00', '5.40', '50.40'),
(178, 'TXN-20250306170057', '2025-03-06 09:01:35', 8, '50.40', '5.00', '5.40', '50.40'),
(179, 'TXN-20250307220452', '2025-03-07 14:05:12', 8, '100.80', '10.00', '10.80', '100.80'),
(180, 'TXN-20250307220932', '2025-03-07 14:09:44', 8, '100.80', '10.00', '10.80', '100.80'),
(181, 'TXN-20250307235609', '2025-03-07 15:56:29', 8, '100.80', '10.00', '10.80', '100.80'),
(182, 'TXN-20250310103758', '2025-03-10 02:39:29', 8, '468.00', '0.00', '0.00', '468.00'),
(183, 'TXN-20250311051043', '2025-03-10 21:12:14', 8, '229.82', '22.80', '24.62', '229.82'),
(184, 'TXN-20250319193913', '2025-03-19 11:39:32', 54, '12.10', '1.21', '1.30', '10.89'),
(185, 'TXN-20250319213534', '2025-03-19 13:36:49', 55, '12.10', '1.21', '1.30', '10.89');

-- --------------------------------------------------------

--
-- Table structure for table `sale_items`
--

CREATE TABLE `sale_items` (
  `sale_item_id` int NOT NULL,
  `sale_id` int NOT NULL,
  `product_id` int NOT NULL,
  `quantity` int NOT NULL,
  `unit_price` decimal(10,2) NOT NULL,
  `total_price` decimal(10,2) NOT NULL,
  `discount_applied` decimal(10,2) DEFAULT '0.00'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `sale_items`
--

INSERT INTO `sale_items` (`sale_item_id`, `sale_id`, `product_id`, `quantity`, `unit_price`, `total_price`, `discount_applied`) VALUES
(127, 102, 19, 1, '12.00', '12.00', '0.00'),
(128, 103, 19, 1, '12.00', '12.00', '0.00'),
(129, 104, 19, 1, '12.00', '12.00', '0.00'),
(130, 105, 20, 7, '50.00', '350.00', '0.00'),
(131, 105, 21, 7, '15.00', '105.00', '0.00'),
(132, 106, 20, 5, '50.00', '250.00', '0.00'),
(133, 107, 20, 3, '50.00', '150.00', '0.00'),
(134, 108, 20, 2, '50.00', '100.00', '0.00'),
(135, 109, 20, 10, '50.00', '500.00', '0.00'),
(136, 110, 21, 10, '15.00', '150.00', '0.00'),
(137, 111, 20, 3, '50.00', '150.00', '0.00'),
(138, 112, 20, 3, '50.00', '150.00', '0.00'),
(139, 113, 20, 6, '50.00', '300.00', '0.00'),
(140, 114, 22, 7, '50.00', '350.00', '0.00'),
(141, 115, 22, 2, '50.00', '100.00', '0.00'),
(142, 116, 22, 2, '50.00', '100.00', '0.00'),
(143, 117, 22, 1, '50.00', '50.00', '0.00'),
(144, 118, 25, 1, '115.00', '115.00', '0.00'),
(145, 119, 22, 1, '50.00', '50.00', '0.00'),
(146, 120, 22, 1, '50.00', '50.00', '0.00'),
(147, 121, 22, 1, '50.00', '50.00', '0.00'),
(148, 122, 22, 1, '50.00', '50.00', '0.00'),
(149, 123, 22, 15, '50.00', '750.00', '0.00'),
(150, 124, 22, 3, '50.00', '150.00', '0.00'),
(151, 125, 22, 2, '50.00', '100.00', '0.00'),
(152, 126, 22, 1, '50.00', '50.00', '0.00'),
(153, 127, 22, 3, '50.00', '150.00', '0.00'),
(154, 128, 26, 1, '48.00', '48.00', '0.00'),
(155, 128, 22, 2, '50.00', '100.00', '0.00'),
(156, 129, 22, 4, '50.00', '200.00', '0.00'),
(157, 130, 22, 2, '50.00', '100.00', '0.00'),
(158, 131, 22, 1, '50.00', '50.00', '0.00'),
(159, 132, 25, 1, '115.00', '115.00', '0.00'),
(160, 133, 22, 1, '50.00', '50.00', '0.00'),
(161, 134, 22, 3, '50.00', '150.00', '0.00'),
(162, 136, 22, 2, '50.00', '100.00', '0.00'),
(163, 137, 22, 1, '50.00', '50.00', '0.00'),
(164, 158, 22, 2, '50.00', '100.00', '0.00'),
(165, 159, 22, 4, '50.00', '200.00', '0.00'),
(166, 160, 22, 4, '50.00', '200.00', '0.00'),
(167, 161, 22, 2, '50.00', '100.00', '0.00'),
(168, 162, 22, 6, '50.00', '300.00', '0.00'),
(169, 163, 22, 1, '50.00', '50.00', '0.00'),
(170, 164, 22, 2, '50.00', '100.00', '0.00'),
(171, 168, 22, 1, '50.00', '50.00', '0.00'),
(172, 169, 22, 1, '50.00', '50.00', '0.00'),
(173, 170, 22, 1, '50.00', '50.00', '0.00'),
(174, 171, 22, 1, '50.00', '50.00', '0.00'),
(175, 172, 22, 1, '50.00', '50.00', '0.00'),
(176, 173, 22, 1, '50.00', '50.00', '0.00'),
(177, 174, 22, 2, '50.00', '100.00', '0.00'),
(178, 175, 22, 1, '50.00', '50.00', '0.00'),
(179, 176, 22, 3, '50.00', '150.00', '0.00'),
(180, 177, 22, 1, '50.00', '50.00', '0.00'),
(181, 178, 22, 1, '50.00', '50.00', '0.00'),
(182, 179, 22, 2, '50.00', '100.00', '0.00'),
(183, 180, 22, 2, '50.00', '100.00', '0.00'),
(184, 181, 22, 2, '50.00', '100.00', '0.00'),
(185, 182, 36, 2, '234.00', '468.00', '0.00'),
(186, 183, 47, 14, '12.00', '168.00', '0.00'),
(187, 183, 46, 4, '12.00', '48.00', '0.00'),
(188, 183, 48, 1, '12.00', '12.00', '0.00'),
(189, 184, 46, 1, '12.00', '12.00', '0.00'),
(190, 185, 46, 1, '12.00', '12.00', '0.00');

-- --------------------------------------------------------

--
-- Table structure for table `suppliers`
--

CREATE TABLE `suppliers` (
  `supplier_id` int NOT NULL,
  `supplier_name` varchar(100) COLLATE utf8mb4_general_ci NOT NULL,
  `contact_number` varchar(15) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `address` text COLLATE utf8mb4_general_ci,
  `email` varchar(100) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `suppliers`
--

INSERT INTO `suppliers` (`supplier_id`, `supplier_name`, `contact_number`, `address`, `email`, `created_at`, `updated_at`) VALUES
(9, 'Oishi1', '09092114861', 'Taguig, Western', 'Oishiph@gmail.com', '2024-12-07 00:28:47', '2024-12-07 00:42:48'),
(10, 'JacknJill', '09328217121', 'Taguig, Hagonoy', 'JacknJillph@gmail.com', '2024-12-07 00:29:50', '2024-12-07 00:29:50'),
(12, 'JacknJill', '09328217121', 'Makati', 'JacknJillph@gmail.com', '2024-12-07 00:30:17', '2024-12-07 00:31:12'),
(18, 'test', '09757953206', 'test1', 'test@gmail.com', '2025-03-09 07:52:19', '2025-03-09 07:52:19');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `user_id` int NOT NULL,
  `username` varchar(50) COLLATE utf8mb4_general_ci NOT NULL,
  `full_name` varchar(100) COLLATE utf8mb4_general_ci NOT NULL,
  `email` varchar(100) COLLATE utf8mb4_general_ci NOT NULL,
  `password_hash` varchar(255) COLLATE utf8mb4_general_ci NOT NULL,
  `role` enum('Admin','Cashier','Staff') COLLATE utf8mb4_general_ci NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `address` varchar(255) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `age` int DEFAULT NULL,
  `gender` varchar(10) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `first_name` varchar(50) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `middle_initial` varchar(5) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `last_name` varchar(50) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `profile_picture` mediumblob
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`user_id`, `username`, `full_name`, `email`, `password_hash`, `role`, `created_at`, `updated_at`, `address`, `age`, `gender`, `first_name`, `middle_initial`, `last_name`, `profile_picture`) VALUES
(8, 'admin', 'Administrator', '', '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', 'Admin', '2024-11-26 07:48:37', '2024-11-26 07:48:37', NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(54, 'cashier', 'cashierrrrr c cashierrrrr', 'test123@gmail.com', '6a79b51fec89db977e62d3b5aee3ea8b9de93cabf2446aae7d6f517db6d16178', 'Cashier', '2025-03-19 11:21:54', '2025-03-19 11:21:54', 'test123', 20, 'Male', 'cashierrrrr', 'c', 'cashierrrrr', NULL),
(55, 'cjcashier', 'joshua a arm', 'asd@mail.com', '5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8', 'Cashier', '2025-03-19 13:34:32', '2025-03-19 13:34:32', 'asd', 20, 'Male', 'joshua', 'a', 'arm', NULL),
(56, 'cjstaff', 'cj ja jc', 'asd@gmail.com', '5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8', 'Staff', '2025-03-19 13:35:13', '2025-03-19 13:35:13', 'dasd', 20, 'Male', 'cj', 'ja', 'jc', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `vat`
--

CREATE TABLE `vat` (
  `vat_id` int NOT NULL,
  `vat_rate` decimal(5,2) NOT NULL,
  `effective_date` date DEFAULT (curdate()),
  `created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `vat`
--

INSERT INTO `vat` (`vat_id`, `vat_rate`, `effective_date`, `created_at`) VALUES
(15, '12.00', '0000-00-00', '2025-03-10 04:32:56');

--
-- Triggers `vat`
--
DELIMITER $$
CREATE TRIGGER `check_vat_rate` BEFORE INSERT ON `vat` FOR EACH ROW BEGIN
    IF NEW.vat_rate < 0 OR NEW.vat_rate > 100 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'VAT rate must be between 0 and 100';
    END IF;
END
$$
DELIMITER ;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `audittrail`
--
ALTER TABLE `audittrail`
  ADD PRIMARY KEY (`AuditID`);

--
-- Indexes for table `categories`
--
ALTER TABLE `categories`
  ADD PRIMARY KEY (`category_id`);

--
-- Indexes for table `deliveries`
--
ALTER TABLE `deliveries`
  ADD PRIMARY KEY (`delivery_id`),
  ADD UNIQUE KEY `transaction_number` (`transaction_number`),
  ADD KEY `supplier_id` (`supplier_id`);

--
-- Indexes for table `delivery_items`
--
ALTER TABLE `delivery_items`
  ADD PRIMARY KEY (`delivery_item_id`),
  ADD KEY `delivery_id` (`delivery_id`),
  ADD KEY `product_id` (`product_id`);

--
-- Indexes for table `discounts`
--
ALTER TABLE `discounts`
  ADD PRIMARY KEY (`discount_id`);

--
-- Indexes for table `inventory`
--
ALTER TABLE `inventory`
  ADD PRIMARY KEY (`inventory_id`),
  ADD KEY `product_id` (`product_id`);

--
-- Indexes for table `loghistory`
--
ALTER TABLE `loghistory`
  ADD PRIMARY KEY (`LogID`);

--
-- Indexes for table `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`product_id`),
  ADD UNIQUE KEY `barcode` (`barcode`),
  ADD KEY `category_id` (`category_id`);

--
-- Indexes for table `sales`
--
ALTER TABLE `sales`
  ADD PRIMARY KEY (`sale_id`),
  ADD UNIQUE KEY `transaction_number` (`transaction_number`),
  ADD KEY `idx_cashier_id` (`cashier_id`);

--
-- Indexes for table `sale_items`
--
ALTER TABLE `sale_items`
  ADD PRIMARY KEY (`sale_item_id`),
  ADD KEY `sale_id` (`sale_id`),
  ADD KEY `product_id` (`product_id`);

--
-- Indexes for table `suppliers`
--
ALTER TABLE `suppliers`
  ADD PRIMARY KEY (`supplier_id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`user_id`),
  ADD UNIQUE KEY `username` (`username`),
  ADD KEY `idx_user_id` (`user_id`);

--
-- Indexes for table `vat`
--
ALTER TABLE `vat`
  ADD PRIMARY KEY (`vat_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `audittrail`
--
ALTER TABLE `audittrail`
  MODIFY `AuditID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=66;

--
-- AUTO_INCREMENT for table `categories`
--
ALTER TABLE `categories`
  MODIFY `category_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT for table `deliveries`
--
ALTER TABLE `deliveries`
  MODIFY `delivery_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=411;

--
-- AUTO_INCREMENT for table `delivery_items`
--
ALTER TABLE `delivery_items`
  MODIFY `delivery_item_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=204;

--
-- AUTO_INCREMENT for table `discounts`
--
ALTER TABLE `discounts`
  MODIFY `discount_id` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `inventory`
--
ALTER TABLE `inventory`
  MODIFY `inventory_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `loghistory`
--
ALTER TABLE `loghistory`
  MODIFY `LogID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=614;

--
-- AUTO_INCREMENT for table `products`
--
ALTER TABLE `products`
  MODIFY `product_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=49;

--
-- AUTO_INCREMENT for table `sales`
--
ALTER TABLE `sales`
  MODIFY `sale_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=186;

--
-- AUTO_INCREMENT for table `sale_items`
--
ALTER TABLE `sale_items`
  MODIFY `sale_item_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=191;

--
-- AUTO_INCREMENT for table `suppliers`
--
ALTER TABLE `suppliers`
  MODIFY `supplier_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `user_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=57;

--
-- AUTO_INCREMENT for table `vat`
--
ALTER TABLE `vat`
  MODIFY `vat_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `deliveries`
--
ALTER TABLE `deliveries`
  ADD CONSTRAINT `deliveries_ibfk_1` FOREIGN KEY (`supplier_id`) REFERENCES `suppliers` (`supplier_id`) ON DELETE CASCADE,
  ADD CONSTRAINT `fk_supplier` FOREIGN KEY (`supplier_id`) REFERENCES `suppliers` (`supplier_id`);

--
-- Constraints for table `delivery_items`
--
ALTER TABLE `delivery_items`
  ADD CONSTRAINT `delivery_items_ibfk_2` FOREIGN KEY (`product_id`) REFERENCES `products` (`product_id`) ON DELETE CASCADE;

--
-- Constraints for table `inventory`
--
ALTER TABLE `inventory`
  ADD CONSTRAINT `inventory_ibfk_1` FOREIGN KEY (`product_id`) REFERENCES `products` (`product_id`);

--
-- Constraints for table `sales`
--
ALTER TABLE `sales`
  ADD CONSTRAINT `sales_ibfk_1` FOREIGN KEY (`cashier_id`) REFERENCES `users` (`user_id`);

--
-- Constraints for table `sale_items`
--
ALTER TABLE `sale_items`
  ADD CONSTRAINT `sale_items_ibfk_1` FOREIGN KEY (`sale_id`) REFERENCES `sales` (`sale_id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
