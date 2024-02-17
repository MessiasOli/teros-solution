import clsx from "clsx";
import React, { useRef, ReactNode } from "react";

type TSize = "full" | "xl" | "lg" | "sm";

interface ModalProps {
  isOpen: boolean;
  onClose: () => void;
  children: ReactNode;
  size?: TSize;
}

const ModalGeneric: React.FC<ModalProps> = ({ isOpen, onClose, children, size = "full" }) => {
  const dialogRef = useRef<HTMLDialogElement | null>(null);

  const handleClose = () => {
    dialogRef.current?.close();
    onClose();
  };

  return (
    <dialog
      ref={dialogRef}
      open={isOpen}
      className={`opacity-100 w-full h-screen z-[999] absolute left-0 top-0 pt-24 overflow-auto bg-modal flex justify-center items-start ${
        isOpen ? "block" : "hidden"
      }`}
    >
      <div
        className={clsx(
          "bg-white rounded-md w-10/12 z-50",
          size === "sm" && "w-[32rem]",
          size === "lg" && "w-[52rem]",
          size === "xl" && "w-[72rem]",
          size === "full" && "w-full"
        )}
      >
        <div className="flex justify-end my-2">
          <button
            onClick={handleClose}
            className="mr-4 py-1 px-2 rounded "
          >
            x
          </button>
        </div>
        {children}
      </div>
    </dialog>
  );
};

export default ModalGeneric;
